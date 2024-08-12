namespace VectorLevelManager
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.listBoxMaps = new System.Windows.Forms.ListBox();
            this.AddMapButton = new System.Windows.Forms.Button();
            this.RemoveMapButton = new System.Windows.Forms.Button();
            this.PanelDetails = new System.Windows.Forms.Panel();
            this.labelReplaceMapName = new System.Windows.Forms.Label();
            this.labelReplaceMap = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelAuthorTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelLevelName = new System.Windows.Forms.Label();
            this.LabelThumbnail = new System.Windows.Forms.Panel();
            this.textboxPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonCompile = new System.Windows.Forms.Button();
            this.labelVectorPath = new System.Windows.Forms.Label();
            this.ButtonRevertMap = new System.Windows.Forms.Button();
            this.ButtonCompileFast = new System.Windows.Forms.Button();
            this.ButtonInformation = new System.Windows.Forms.Button();
            this.PanelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxMaps
            // 
            this.listBoxMaps.FormattingEnabled = true;
            this.listBoxMaps.HorizontalScrollbar = true;
            this.listBoxMaps.Location = new System.Drawing.Point(12, 12);
            this.listBoxMaps.Name = "listBoxMaps";
            this.listBoxMaps.Size = new System.Drawing.Size(240, 355);
            this.listBoxMaps.Sorted = true;
            this.listBoxMaps.TabIndex = 0;
            this.listBoxMaps.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // AddMapButton
            // 
            this.AddMapButton.Location = new System.Drawing.Point(12, 380);
            this.AddMapButton.Name = "AddMapButton";
            this.AddMapButton.Size = new System.Drawing.Size(112, 23);
            this.AddMapButton.TabIndex = 1;
            this.AddMapButton.Text = "Add Level";
            this.AddMapButton.UseVisualStyleBackColor = true;
            this.AddMapButton.Click += new System.EventHandler(this.AddMapButton_Click);
            // 
            // RemoveMapButton
            // 
            this.RemoveMapButton.Location = new System.Drawing.Point(140, 380);
            this.RemoveMapButton.Name = "RemoveMapButton";
            this.RemoveMapButton.Size = new System.Drawing.Size(112, 23);
            this.RemoveMapButton.TabIndex = 2;
            this.RemoveMapButton.Text = "Remove Level";
            this.RemoveMapButton.UseVisualStyleBackColor = true;
            this.RemoveMapButton.Click += new System.EventHandler(this.RemoveMapButton_Click);
            // 
            // PanelDetails
            // 
            this.PanelDetails.Controls.Add(this.labelReplaceMapName);
            this.PanelDetails.Controls.Add(this.labelReplaceMap);
            this.PanelDetails.Controls.Add(this.labelAuthor);
            this.PanelDetails.Controls.Add(this.labelAuthorTitle);
            this.PanelDetails.Controls.Add(this.labelDescription);
            this.PanelDetails.Controls.Add(this.labelLevelName);
            this.PanelDetails.Controls.Add(this.LabelThumbnail);
            this.PanelDetails.Location = new System.Drawing.Point(270, 12);
            this.PanelDetails.Name = "PanelDetails";
            this.PanelDetails.Size = new System.Drawing.Size(518, 549);
            this.PanelDetails.TabIndex = 3;
            // 
            // labelReplaceMapName
            // 
            this.labelReplaceMapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReplaceMapName.Location = new System.Drawing.Point(169, 515);
            this.labelReplaceMapName.Name = "labelReplaceMapName";
            this.labelReplaceMapName.Size = new System.Drawing.Size(376, 16);
            this.labelReplaceMapName.TabIndex = 10;
            this.labelReplaceMapName.Text = "DOWNTOWN_STORY_02";
            // 
            // labelReplaceMap
            // 
            this.labelReplaceMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReplaceMap.Location = new System.Drawing.Point(164, 497);
            this.labelReplaceMap.Name = "labelReplaceMap";
            this.labelReplaceMap.Size = new System.Drawing.Size(72, 18);
            this.labelReplaceMap.TabIndex = 9;
            this.labelReplaceMap.Text = "Replacing:";
            // 
            // labelAuthor
            // 
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(16, 515);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(185, 16);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "author_name";
            // 
            // labelAuthorTitle
            // 
            this.labelAuthorTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorTitle.Location = new System.Drawing.Point(11, 497);
            this.labelAuthorTitle.Name = "labelAuthorTitle";
            this.labelAuthorTitle.Size = new System.Drawing.Size(57, 18);
            this.labelAuthorTitle.TabIndex = 7;
            this.labelAuthorTitle.Text = "Author:";
            // 
            // labelDescription
            // 
            this.labelDescription.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(11, 375);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(502, 112);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "description...";
            // 
            // labelLevelName
            // 
            this.labelLevelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevelName.Location = new System.Drawing.Point(11, 356);
            this.labelLevelName.Name = "labelLevelName";
            this.labelLevelName.Size = new System.Drawing.Size(484, 19);
            this.labelLevelName.TabIndex = 5;
            this.labelLevelName.Text = "Level";
            // 
            // LabelThumbnail
            // 
            this.LabelThumbnail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LabelThumbnail.BackgroundImage")));
            this.LabelThumbnail.Location = new System.Drawing.Point(6, 7);
            this.LabelThumbnail.Name = "LabelThumbnail";
            this.LabelThumbnail.Size = new System.Drawing.Size(507, 340);
            this.LabelThumbnail.TabIndex = 4;
            // 
            // textboxPath
            // 
            this.textboxPath.Location = new System.Drawing.Point(12, 438);
            this.textboxPath.Name = "textboxPath";
            this.textboxPath.Size = new System.Drawing.Size(240, 20);
            this.textboxPath.TabIndex = 4;
            this.textboxPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(140, 464);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(112, 28);
            this.buttonBrowse.TabIndex = 5;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // buttonCompile
            // 
            this.buttonCompile.Location = new System.Drawing.Point(15, 503);
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.Size = new System.Drawing.Size(80, 58);
            this.buttonCompile.TabIndex = 6;
            this.buttonCompile.Text = "Compile Map";
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.ButtonCompile_Click);
            // 
            // labelVectorPath
            // 
            this.labelVectorPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVectorPath.Location = new System.Drawing.Point(12, 416);
            this.labelVectorPath.Name = "labelVectorPath";
            this.labelVectorPath.Size = new System.Drawing.Size(240, 19);
            this.labelVectorPath.TabIndex = 11;
            this.labelVectorPath.Text = "Vector\'s Directory Path:";
            // 
            // ButtonRevertMap
            // 
            this.ButtonRevertMap.Location = new System.Drawing.Point(184, 504);
            this.ButtonRevertMap.Name = "ButtonRevertMap";
            this.ButtonRevertMap.Size = new System.Drawing.Size(68, 57);
            this.ButtonRevertMap.TabIndex = 12;
            this.ButtonRevertMap.Text = "Revert XML";
            this.ButtonRevertMap.UseVisualStyleBackColor = true;
            this.ButtonRevertMap.Click += new System.EventHandler(this.ButtonRevertMap_Click);
            // 
            // ButtonCompileFast
            // 
            this.ButtonCompileFast.Location = new System.Drawing.Point(101, 504);
            this.ButtonCompileFast.Name = "ButtonCompileFast";
            this.ButtonCompileFast.Size = new System.Drawing.Size(77, 58);
            this.ButtonCompileFast.TabIndex = 13;
            this.ButtonCompileFast.Text = "Compile Map (Fast)";
            this.ButtonCompileFast.UseVisualStyleBackColor = true;
            this.ButtonCompileFast.Click += new System.EventHandler(this.ButtonCompileFast_Click);
            // 
            // ButtonInformation
            // 
            this.ButtonInformation.Image = ((System.Drawing.Image)(resources.GetObject("ButtonInformation.Image")));
            this.ButtonInformation.Location = new System.Drawing.Point(12, 464);
            this.ButtonInformation.Name = "ButtonInformation";
            this.ButtonInformation.Size = new System.Drawing.Size(29, 28);
            this.ButtonInformation.TabIndex = 14;
            this.ButtonInformation.UseVisualStyleBackColor = true;
            this.ButtonInformation.Click += new System.EventHandler(this.ButtonInformation_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 584);
            this.Controls.Add(this.ButtonInformation);
            this.Controls.Add(this.ButtonCompileFast);
            this.Controls.Add(this.ButtonRevertMap);
            this.Controls.Add(this.labelVectorPath);
            this.Controls.Add(this.buttonCompile);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textboxPath);
            this.Controls.Add(this.PanelDetails);
            this.Controls.Add(this.RemoveMapButton);
            this.Controls.Add(this.AddMapButton);
            this.Controls.Add(this.listBoxMaps);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Vector Level Manager 1.1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.PanelDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMaps;
        private System.Windows.Forms.Button AddMapButton;
        private System.Windows.Forms.Button RemoveMapButton;
        private System.Windows.Forms.Panel PanelDetails;
        private System.Windows.Forms.Panel LabelThumbnail;
        private System.Windows.Forms.Label labelLevelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelAuthorTitle;
        private System.Windows.Forms.TextBox textboxPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.Label labelReplaceMapName;
        private System.Windows.Forms.Label labelReplaceMap;
        private System.Windows.Forms.Label labelVectorPath;
        private System.Windows.Forms.Button ButtonRevertMap;
        private System.Windows.Forms.Button ButtonCompileFast;
        private System.Windows.Forms.Button ButtonInformation;
    }
}

