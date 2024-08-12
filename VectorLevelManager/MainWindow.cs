using System.Drawing;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace VectorLevelManager
{
    public partial class MainWindow : Form
    {
        private Dictionary<string, string> mapFolders = new Dictionary<string, string>();
        private BackgroundWorker bgWorker = new BackgroundWorker();
        private const string saveFilePath = "mapData.xml";

        public MainWindow()
        {
            InitializeComponent();

            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.WorkerSupportsCancellation = true;

            LoadMapData();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.FormClosing += MainWindow_FormClosing;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveMapData();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMaps.SelectedItem == null) return;

            string selectedMapFolder = mapFolders[listBoxMaps.SelectedItem.ToString()];
            string configFilePath = Path.Combine(selectedMapFolder, "level_info.cfg");

            if (File.Exists(configFilePath))
            {
                XDocument doc = XDocument.Load(configFilePath);
                var levelElement = doc.Element("Main");

                if (levelElement != null)
                {
                    labelLevelName.Text = levelElement.Attribute("Name")?.Value;
                    labelAuthor.Text = levelElement.Attribute("Author")?.Value;
                    labelDescription.Text = levelElement.Attribute("Description")?.Value;
                    labelReplaceMapName.Text = levelElement.Attribute("ReplaceMap")?.Value;

                    string thumbnailPath = Path.Combine(selectedMapFolder, "level_thumbnail.png");
                    LabelThumbnail.BackgroundImage = File.Exists(thumbnailPath) ? Image.FromFile(thumbnailPath) : null;
                }
            }
        }

        private void AddMapButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { ValidateNames = false, CheckFileExists = false, CheckPathExists = true, FileName = "Folder Selection." })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string mapFolder = Path.GetDirectoryName(ofd.FileName);
                    string configFilePath = Path.Combine(mapFolder, "level_info.cfg");

                    if (File.Exists(configFilePath))
                    {
                        string folderName = Path.GetFileName(mapFolder);
                        listBoxMaps.Items.Add(folderName);
                        mapFolders[folderName] = mapFolder;
                    }
                    else
                    {
                        MessageBox.Show("Selected folder does not contain a valid level_info.cfg file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RemoveMapButton_Click(object sender, EventArgs e)
        {
            if (listBoxMaps.SelectedItem == null) return;

            string selectedMap = listBoxMaps.SelectedItem.ToString();
            listBoxMaps.Items.Remove(selectedMap);
            mapFolders.Remove(selectedMap);
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { ValidateNames = false, CheckFileExists = false, CheckPathExists = true, FileName = "Folder Selection." })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textboxPath.Text = Path.GetDirectoryName(ofd.FileName);
                }
            }
        }

        private void ButtonCompile_Click(object sender, EventArgs e)
        {
            StartBackgroundWorker("compile-map.bat");
        }

        private void ButtonCompileFast_Click(object sender, EventArgs e)
        {
            StartBackgroundWorker("compile-map-optimized.bat");
        }

        private void StartBackgroundWorker(string batchFileName)
        {
            ProgressForm progressForm = new ProgressForm();
            bgWorker.RunWorkerAsync(new object[] { progressForm, batchFileName });
            progressForm.ShowDialog();
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = (object[])e.Argument;
            ProgressForm progressForm = (ProgressForm)args[0];
            string batchFileName = (string)args[1];

            string resourceDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "dzip");

            foreach (var item in listBoxMaps.Items)
            {
                string mapFolder = mapFolders[item.ToString()];
                string configFilePath = Path.Combine(mapFolder, "level_info.cfg");

                if (File.Exists(configFilePath))
                {
                    XElement config = XElement.Load(configFilePath);
                    string levelDirectory = config.Attribute("LevelDirectory")?.Value;
                    string replaceMap = config.Attribute("ReplaceMap")?.Value;

                    if (!string.IsNullOrEmpty(levelDirectory) && !string.IsNullOrEmpty(replaceMap))
                    {
                        string levelPath = Path.Combine(mapFolder, levelDirectory);
                        if (File.Exists(levelPath))
                        {
                            string levelDestinationPath = Path.Combine(resourceDirectory, "level_xml", replaceMap);
                            File.Copy(levelPath, levelDestinationPath, true);
                        }
                    }
                }
            }

            // Execute the batch file and set the result
            e.Result = ExecuteBatchFile(resourceDirectory, batchFileName);
        }


        private string ExecuteBatchFile(string workingDirectory, string batchFileName)
        {
            string batchFilePath = Path.Combine(workingDirectory, batchFileName);

            try
            {
                using (Process batchProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = batchFilePath,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        WorkingDirectory = workingDirectory
                    }
                })
                {
                    batchProcess.Start();
                    string output = batchProcess.StandardOutput.ReadToEnd();
                    string error = batchProcess.StandardError.ReadToEnd();
                    batchProcess.WaitForExit();

                    if (batchProcess.ExitCode != 0)
                    {
                        return $"Compilation encountered an error: {error}";
                    }

                    // Wait for the compilation to finish
                    WaitForCompilationToFinish(batchProcess);

                    // Copy the compiled file after the process exits successfully
                    CopyCompiledFile(workingDirectory, textboxPath.Text, "level_xml.dz");

                    return "Map compilation completed and file copied successfully.";
                }
            }
            catch (Exception ex)
            {
                return $"Failed to start compilation process: {ex.Message}";
            }
        }

        private void WaitForCompilationToFinish(Process batchProcess)
        {
            // Wait for the batch process to finish
            while (!batchProcess.HasExited)
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        private void CopyCompiledFile(string sourceDirectory, string destinationDirectory, string fileName)
        {
            string sourcePath = Path.Combine(sourceDirectory, fileName);
            string destPath = Path.Combine(destinationDirectory, fileName);
            File.Copy(sourcePath, destPath, true);
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object[] results = (object[])e.Result;
            string message = (string)results[0];
            ProgressForm progressForm = (ProgressForm)results[1];

            if (e.Error != null)
            {
                MessageBox.Show($"An error occurred: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Compilation was cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            progressForm?.Close();
        }

        private void ButtonRevertMap_Click(object sender, EventArgs e)
        {
            string sourceDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "dzip", "level_xml_original");
            string destinationDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "dzip", "level_xml");

            try
            {
                foreach (string filePath in Directory.GetFiles(sourceDirectory))
                {
                    string fileName = Path.GetFileName(filePath);
                    string destFilePath = Path.Combine(destinationDirectory, fileName);
                    File.Copy(filePath, destFilePath, true);
                }

                MessageBox.Show("Reverted map files successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to revert map files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveMapData()
        {
            try
            {
                var entries = mapFolders.Select(kvp => new MapFolderEntry { Key = kvp.Key, Value = kvp.Value }).ToList();
                XmlSerializer serializer = new XmlSerializer(typeof(List<MapFolderEntry>));

                // Remove namespaces
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                using (FileStream fs = new FileStream(saveFilePath, FileMode.Create))
                {
                    serializer.Serialize(fs, entries, ns);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save map data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMapData()
        {
            if (File.Exists(saveFilePath))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<MapFolderEntry>));
                    using (FileStream fs = new FileStream(saveFilePath, FileMode.Open))
                    {
                        List<MapFolderEntry> entries = (List<MapFolderEntry>)serializer.Deserialize(fs);
                        mapFolders = entries.ToDictionary(e => e.Key, e => e.Value);
                        foreach (var mapFolder in mapFolders.Keys)
                        {
                            listBoxMaps.Items.Add(mapFolder);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load map data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        [Serializable]
        public class MapFolderEntry
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        private void ButtonInformation_Click(object sender, EventArgs e)
        {
            string information = "Vector Level Manager allows you to easily manage multiple levels\n\n" +
                        "The level added will appear in the list, Compiling the map will replace the level_xml.dz inside your Vector's Directory. You can also revert the xml back to its original by pressing the Revert XML button.\n\n" +
                        "NOTES: Your level list will be saved upon exiting.";
            MessageBox.Show(information, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
