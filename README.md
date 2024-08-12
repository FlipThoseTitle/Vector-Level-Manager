# Vector Level Manager
 Vector Level Manager allows you to easily manage multiple levels in one place without having to mess around inside the XML folder, Ideally this should speedup the process of adding level and make it much less of a hassle.

 ![image](https://github.com/user-attachments/assets/8cdbc786-d1dd-45f7-b546-dd2862d9d701)

## Instruction
- After entering the VLM, set your Vector's Destination Path to where your game is located. (e.g. C:\Program Files (x86)\Steam\steamapps\common\Vector)
- Press add level and select the folder of the map you wanted to add.
- Compile the map after you're done, the level_xml.dz should automatically copy over to your Vector's Directory.

If you wish to revert the content inside the level_xml folder back to the original, press Revert XML. VLM have a save data, which mean you can come back anytime without losing your progress.

## Level Format
Folder containing 1 folder and 2 files.
- Level Folder (containing the .xml of the level)
- level_info.cfg
- level_thumbnail.png

level_info.cfg:
```
ImgFile = "level_thumbnail.png"  - Thumbnail to display in the LVM
    Name = "Template Level"  - Name of the Level to display in the LVM
    Author = "Template Author"  - Creator of the level
    
    LevelDirectory = "Level/LevelTemplate.xml" - Path to your .xml level file
    ReplaceMap = "DOWNTOWN_STORY_02.xml"  - Which map to replace in-game.
    Description - Description of the level to display in LVM
```

Current version: 1.1
