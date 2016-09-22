using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Diagnostics;

using Newtonsoft.Json;

using Ionic.Zip;
using Ionic.Crc;

using Scrapcenter.Util;
using Scrapcenter.GameObjects;

namespace Scrapcenter
{
    public partial class MainWindow : Form
    {
        enum MainPage
        {
            Home,
            Mods,
            Skins,
            Tutorials,
            Backups
        }

        const string CURRENT_VERSION_ID = "2";
        const string LATEST_VERSION_URL = "http://scrapcenter.net/latestversion.php?product=scrapcenter";

        #region Variables
        // Loaded mods
        List<ModInfo> Mods = new List<ModInfo>();
        List<string> ModIDs = new List<string>();

        // Other vars
        MainPage CurrentMainPage = MainPage.Home;
        public string ScrapMechanicFolder;
        Exception latestException = null;
        #endregion

        #region Properties
        ModInfo CurrentMod
        {
            get
            {
                if (!ModSelected)
                    return null;
                return Mods[this.lvInstalledMods.SelectedIndices[0]];
            }
        }

        bool ModSelected
        {
            get
            {
                return this.lvInstalledMods.SelectedIndices.Count > 0;
            }
            set
            {
                if (value == false)
                    this.lvInstalledMods.SelectedIndices.Clear();
            }
        }
        #endregion

        #region Form init
        public MainWindow()
        {
            InitializeComponent();
        }

        void FixSmPath(bool first = true, string prev = null)
        {
            if (first == false)
            {
                DialogResult r = MessageBox.Show("The Scrap Mechanic installation folder could not be found. Please locate it manually", "Scrap Mechanic folder could not be found", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (r != DialogResult.OK)
                    Application.Exit();
            }

            FolderBrowserDialog d = new FolderBrowserDialog();
            if (prev != null)
                d.SelectedPath = prev;
            
            DialogResult r2 = d.ShowDialog();
            if (r2 == DialogResult.OK)
            {
                if (Directory.Exists(d.SelectedPath))
                    Properties.Settings.Default.ScrapMechanicFolder = d.SelectedPath;
                else
                {
                    DialogResult r3 = MessageBox.Show("The located path is not accessible by Scrapcenter. Please try again.", "Not accessible", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (r3 == DialogResult.OK)
                        FixSmPath(false, d.SelectedPath);
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Load sm path
            if (!Directory.Exists(Properties.Settings.Default.ScrapMechanicFolder))
            {
                if (!Directory.Exists(Properties.Settings.Default.ScrapMechanicFolder = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Scrap Mechanic"))
                    if (!Directory.Exists(Properties.Settings.Default.ScrapMechanicFolder = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Scrap Mechanic"))
                        FixSmPath(true, null);
            }

            this.ScrapMechanicFolder = Properties.Settings.Default.ScrapMechanicFolder;

            Directory.CreateDirectory(Path.Combine(ScrapMechanicFolder, "Scrapcenter"));
            Directory.CreateDirectory(Path.Combine(ScrapMechanicFolder, "Scrapcenter", "Mods"));

            // Load mods
            string modListPath = Path.Combine(ScrapMechanicFolder, "Scrapcenter", "modlist.txt");
            if (File.Exists(modListPath))
            {
                string modList = File.ReadAllText(modListPath);
                string[] lines = modList.Split(new char[2] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in lines)
                {
                    string path = Path.Combine(ScrapMechanicFolder, "Scrapcenter", "Mods", line);
                    if (File.Exists(path))
                        LoadMod(path);
                }
            }
            else
            {
                File.Create(modListPath).Close();
            }

            // Load list
            string pAppdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DirectoryInfo dI = new DirectoryInfo(Path.Combine(pAppdata, "Axolot Games", "Scrap Mechanic", "User"));
            if (dI.Exists)
            {
                foreach (DirectoryInfo i in dI.GetDirectories("User_*", SearchOption.TopDirectoryOnly))
                    cbUsers.Items.Add(i.Name.Substring(5));
            }
    
                
            // Apply init layout fixes
            LF_MainMenu(); 
            LF_MainPanel();
            LF_ModList();

            using (System.Net.WebClient c = new System.Net.WebClient())
            {
                using (Stream s = c.OpenRead(LATEST_VERSION_URL))
                {
                    using (StreamReader r = new StreamReader(s))
                    {
                        string[] strs = r.ReadToEnd().Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                        if (strs.Length > 1) {
                            if (strs[0] != CURRENT_VERSION_ID)
                            {
                                DialogResult rq = MessageBox.Show("There is a new version (" + strs[1] + ") available. Do you want to download this version?", "New version available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rq == DialogResult.Yes)
                                {
                                    if (strs.Length > 2)
                                        Process.Start("http://scrapcenter.net/blog/" + strs[2]);
                                    else
                                        Process.Start("http://scrapcenter.net/");
                                }

                            }
                        }
                    }
                }
            }
        }

        public void Shutdown()
        {
            // modinfo.txt
            StringBuilder s = new StringBuilder();
            foreach(ModInfo m in this.Mods) {
                s.AppendLine(new FileInfo(m.FileName).Name);
            }
            StreamWriter wr = File.CreateText(Path.Combine(this.ScrapMechanicFolder, "Scrapcenter", "modlist.txt"));
            wr.Write(s.ToString());
            wr.Flush();
            wr.Close();
            wr = null;

            // Program settings
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Layout Fixes
        /// <summary>
        /// Layout Fix:
        /// Fixed main menu button background color after main page change
        /// </summary>
        private void LF_MainMenu()
        {
            Color ActiveColor = Color.FromArgb(255, 51, 65, 99);
            Color NonActiveColor = Color.Transparent;

            menuBtnHome.BackColor = CurrentMainPage == MainPage.Home ? ActiveColor : NonActiveColor;
            menuBtnMods.BackColor = CurrentMainPage == MainPage.Mods ? ActiveColor : NonActiveColor;
            menuBtnSkins.BackColor = CurrentMainPage == MainPage.Skins ? ActiveColor : NonActiveColor;
            menuBtnTutorials.BackColor = CurrentMainPage == MainPage.Tutorials ? ActiveColor : NonActiveColor;
            menuBtnBackups.BackColor = CurrentMainPage == MainPage.Backups ? ActiveColor : NonActiveColor;
        }

        /// <summary>
        /// Layout Fix:
        /// Make the right panels visible
        /// </summary>
        private void LF_MainPanel()
        {
            mainPanelHome.Visible = CurrentMainPage == MainPage.Home;
            mainPanelMods.Visible = CurrentMainPage == MainPage.Mods;
            mainPanelSkins.Visible = CurrentMainPage == MainPage.Skins;
            mainPanelTutorials.Visible = CurrentMainPage == MainPage.Tutorials;
            mainPanelBackups.Visible = CurrentMainPage == MainPage.Backups;
        }

        private void LF_ModList()
        {
            lvInstalledMods.Items.Clear();
            foreach (ModInfo modInfo in this.Mods)
            {
                string key = "";
                if (modInfo.ModIcon != null) {
                    key = modInfo.AuthorName + "::" + modInfo.ModName;
                    this.modLogoImageList.Images.Add(key, modInfo.ModIcon);
                }
                ListViewItem i = new ListViewItem(modInfo.ModName + " (" + modInfo.AuthorName + ")");
                
                if (key != "")
                    i.ImageKey = key;

                lvInstalledMods.Items.Add(i);
            }

            LF_ModPanel();
        }

        private void LF_ModPanel()
        {
            pnlCurModInfo.Visible = this.ModSelected;
            pnlModsLeft.Size = new Size(this.ModSelected ? 403 : 188, pnlModsLeft.Size.Height);

            if (ModSelected)
            {
                lblModVersion.Text = this.CurrentMod.ModVersion.Replace("&", "&&");
                lblModName.Text = this.CurrentMod.ModName.Replace("&", "&&");
                lblLoaderVersion.Text = this.CurrentMod.LoaderVersion.Replace("&", "&&");
                lblGameVersion.Text = this.CurrentMod.GameVersion.Replace("&", "&&");
                pbModIcon.Image = this.CurrentMod.ModIcon ?? Properties.Resources.logo;
                llblAuthorURL.Visible = this.CurrentMod.AuthorURL != "";
                lblAuthor.Visible = !llblAuthorURL.Visible;

                lblAuthor.Text = llblAuthorURL.Text = this.CurrentMod.AuthorName.Replace("&", "&&") + (this.CurrentMod.Contributors.Count == 0 ? "" : " (+ " + this.CurrentMod.Contributors.Count + ")");
                llblAuthorURL.Visible = this.CurrentMod.AuthorURL != "";

                string toolTipText = this.CurrentMod.Contributors.Count == 0
                    ? ""
                    : "Contributors: " + string.Join(", ", this.CurrentMod.Contributors.ToArray());
                ttContributors.SetToolTip(lblAuthor, toolTipText);
                ttContributors.SetToolTip(llblAuthorURL, toolTipText);

                if (this.CurrentMod.Dependencies.Where((dep) => !this.ModIDs.Contains(dep)).Count() == 0)
                {
                    lblListRequiredModsCaption.Visible = false;
                    lblListRequiredMods.Visible = false;
                }
                else
                {
                    lblListRequiredModsCaption.Visible = true;
                    lblListRequiredMods.Visible = true;
                    StringBuilder dependencies = new StringBuilder();
                    foreach (string dependency in this.CurrentMod.Dependencies.Where((dep) => !this.ModIDs.Contains(dep)))
                    {
                        string[] dependencyInfo = ModInfo.ParseModID(dependency);
                        if (dependencyInfo[1].Length > 0)
                            dependencyInfo[1] = dependencyInfo[1][0].ToString().ToUpper()[0] + dependencyInfo[1].Substring(1);
                        dependencies.AppendLine("– " + dependencyInfo[1] + " (" + dependencyInfo[0] + ")");
                    }
                    lblListRequiredMods.Text = dependencies.ToString();
                    dependencies = null;
                }

                int currentModIndex = this.Mods.IndexOf(this.CurrentMod);
                btnModDown.Enabled = currentModIndex != (this.Mods.Count - 1);
                btnModUp.Enabled = currentModIndex != 0;
            }
        }
        #endregion

        #region Main Page Load
        /// <summary>
        /// Main Page Load:
        /// Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MPL_Home(object sender, EventArgs e)
        {
            CurrentMainPage = MainPage.Home;
            LF_MainPanel();
            LF_MainMenu();
        }

        /// <summary>
        /// Main Page Load:
        /// Mods
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MPL_Mods(object sender, EventArgs e)
        {
            CurrentMainPage = MainPage.Mods;
            LF_MainPanel();
            LF_MainMenu();
        }

        private void MPL_Skins(object sender, EventArgs e)
        {
            CurrentMainPage = MainPage.Skins;
            LF_MainPanel();
            LF_MainMenu();
        }

        private void MPL_Tutorials(object sender, EventArgs e)
        {
            CurrentMainPage = MainPage.Tutorials;
            LF_MainPanel();
            LF_MainMenu();
        }

        private void MPL_Backups(object sender, EventArgs e)
        {
            CurrentMainPage = MainPage.Backups;
            LF_MainPanel();
            LF_MainMenu();
        }
        #endregion

        #region Patching
        private void A_PatchGame(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("ScrapMechanic.exe").Length != 0)
            {
                MessageBox.Show("You cannot install mods while the game is running. Please close it first.", "Please close Scrap Mechanic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult box = MessageBox.Show("Have you verified the game cache?\n\nThis is necessary for the patching to work. Your game might stop working if you skipped the previous step.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (box == DialogResult.Yes)
            {
                // Check for dependency issues
                foreach (ModInfo i in this.Mods)
                {
                    foreach (string dependency in i.Dependencies.Where((d) => !ModIDs.Contains(d)))
                    {
                        try
                        {
                            // Show error
                            string[] dependencyInfo = ModInfo.ParseModID(dependency);
                            MessageBox.Show("Error: Mod " + i.ModName + " requires you have the mod " + dependencyInfo[1] + " by " + dependencyInfo[0], "Mod dependency error");
                            return;
                        }
                        catch
                        { }
                    }
                }

                Dictionary<ModInfo, ZipFile> modZipFiles = new Dictionary<ModInfo, ZipFile>();
                try
                {
                    pbPatch.Value = 5;

                    // Load reader
                    GameReader reader = new GameReader(ScrapMechanicFolder);

                    // 1. Load physics materials
                    // 2. Load blocks
                    // 3. Load rotation sets
                    // 4. Load shapesets
                    // 5. Load inventory item descriptions
                    // 6. Load IconMap images
                    Dictionary<string, Material> materials = reader.ReadPhysicsMaterials();
                    pbPatch.Value = 6;
                    Dictionary<Guid, Block> blocks = reader.ReadBlocks(materials);
                    pbPatch.Value = 7;
                    Dictionary<string, RotationSet> rotationSets = reader.ReadRotationSets();
                    pbPatch.Value = 8;
                    Dictionary<string, ShapeSet> shapeSets = reader.ReadShapesets(rotationSets, materials);
                    pbPatch.Value = 9;
                    Dictionary<Guid, InventoryItemDescription> invItemDescs = reader.ReadInventoryItemDescriptions();
                    pbPatch.Value = 10;
                    Dictionary<Guid, Image> icons = reader.ReadIconMap();
                    pbPatch.Value = 11;

                    Dictionary<string, byte[]> resources = new Dictionary<string, byte[]>();

                    List<string> addedMaterials = new List<string>();
                    List<Guid> addedBlocks = new List<Guid>();
                    List<string> addedRotationSets = new List<string>();
                    List<Guid> addedInvItemDescs = new List<Guid>();
                    List<Guid> addedIcons = new List<Guid>();

                    // 7. Load for all mods mods those things in same order
                    string physicsMaterialsPath = "Data/Objects/Database/physicsmaterials.json";
                    string blocksPath = "Data/Objects/Database/basicmaterials.json";
                    string shapeSetsListPath = "Data/Objects/Database/shapesets.json";
                    string rotationSetsPath = "Data/Objects/Database/rotationsets.json";
                    string inventoryItemDescriptionsPath = "Data/Gui/InventoryItemDescriptions.json";

                    foreach (ModInfo i in this.Mods)
                        modZipFiles[i] = ZipFile.Read(i.FileName);
                    pbPatch.Value = 15;

                    // Read physics materials
                    foreach (ZipFile zip in modZipFiles.Values)
                    {
                        // If the mod offers new Physics Materials
                        if (zip.ContainsEntry(physicsMaterialsPath))
                        {
                            // Read and parse the physics materials
                            Dictionary<string, Material> thisModMaterials = Material.ReadFromJson(Zip.ReadText(zip[physicsMaterialsPath]));
                            // Loop over each material
                            foreach (KeyValuePair<string, Material> kvp in thisModMaterials)
                            {
                                // If there is already a material with this name
                                if (!addedMaterials.Contains(kvp.Key))
                                {
                                    // Add the material to the material dictionary, and make sure it won't be overwritten
                                    materials[kvp.Key] = kvp.Value;
                                    addedMaterials.Add(kvp.Key);
                                }
                            }
                        }
                    }
                    pbPatch.Value = 20;

                    // Read rotation sets
                    foreach (ZipFile zip in modZipFiles.Values)
                    {
                        // If the mod offers new rotation sets
                        if (zip.ContainsEntry(rotationSetsPath))
                        {
                            // Read and parse the rotation sets
                            Dictionary<string, RotationSet> thisModRotationSets = RotationSet.ReadFromJson(Zip.ReadText(zip[rotationSetsPath]));

                            // Loop over each rotation set
                            foreach (KeyValuePair<string, RotationSet> kvp in thisModRotationSets)
                            {
                                // If there is already a rotation set with this name
                                if (!addedRotationSets.Contains(kvp.Key))
                                {
                                    // Add the rotation set to the rotation set dictionary, and make sure it won't be overwritten
                                    rotationSets[kvp.Key] = kvp.Value;
                                    addedRotationSets.Add(kvp.Key);
                                }
                            }
                        }
                    }
                    pbPatch.Value = 25;

                    // Read blocks
                    foreach (ZipFile zip in modZipFiles.Values)
                    {
                        // If the mod offers new rotation sets
                        if (zip.ContainsEntry(blocksPath))
                        {
                            // Read and parse the blocks
                            Dictionary<Guid, Block> thisModBlocks = Block.ReadFromJson(Zip.ReadText(zip[blocksPath]), materials);

                            // Loop over each block
                            foreach (KeyValuePair<Guid, Block> kvp in thisModBlocks)
                            {
                                // If there is already a block with this name
                                if (!addedBlocks.Contains(kvp.Key))
                                {
                                    // Add the block to the rotation set dictionary, and make sure it won't be overwritten
                                    blocks[kvp.Key] = kvp.Value;
                                    addedBlocks.Add(kvp.Key);
                                }
                            }
                        }
                    }
                    pbPatch.Value = 30;

                    // Load ShapeSets
                    foreach (ZipFile zipFile in modZipFiles.Values)
                    {
                        if (zipFile.ContainsEntry(shapeSetsListPath))
                        {
                            // Load the shape set list json to a dictionary
                            string sslJson = Zip.ReadText(zipFile[shapeSetsListPath]);
                            IDictionary<string, object> sslDict = JsonConvert.DeserializeObject<ExpandoObject>(sslJson);

                            // See if it has a shape set list
                            if (sslDict.ContainsKey("shapeSetList"))
                            {
                                // Loop over the shape set list
                                foreach (object lObj in (List<object>)sslDict["shapeSetList"])
                                {
                                    string shapeSetName = lObj.ToString();
                                    if (!shapeSets.ContainsKey(shapeSetName))
                                    {
                                        if (zipFile.ContainsEntry("Data/Objects/Database/ShapeSets/" + shapeSetName))
                                        {
                                            string shapeSetJson = Zip.ReadText(zipFile["Data/Objects/Database/ShapeSets/" + shapeSetName]);
                                            shapeSets[shapeSetName] = new ShapeSet(shapeSetName, shapeSetJson, rotationSets, materials);
                                        }
                                    }
                                    else
                                        throw new Exception("There is already a ShapeSet named " + shapeSetName + ".\n\nIf you are the mod maker: To prevent name collisions, prefix your shapesets with your username, and give every ShapeSet in your mods a different name.");
                                }
                            }
                        }
                    }
                    pbPatch.Value = 35;

                    // Load inventory items
                    foreach (ZipFile zip in modZipFiles.Values)
                    {
                        // If the mod has an Inventory Item Descriptions file
                        if (zip.ContainsEntry(inventoryItemDescriptionsPath))
                        {
                            // Load the description items
                            Dictionary<Guid, InventoryItemDescription> descs = InventoryItemDescription.ReadFromJson(Zip.ReadText(zip[inventoryItemDescriptionsPath]));
                            foreach (KeyValuePair<Guid, InventoryItemDescription> kvp in descs)
                            {
                                // If no (custom) description for this item exists yet; add one and make sure it won't be overwritten
                                if (!addedInvItemDescs.Contains(kvp.Key))
                                {
                                    addedInvItemDescs.Add(kvp.Key);
                                    invItemDescs[kvp.Key] = kvp.Value;
                                }
                            }
                        }
                    }
                    pbPatch.Value = 40;

                    // Load inventory icons
                    foreach (ZipFile zip in modZipFiles.Values)
                    {
                        // If this mod both has a icon information file ...
                        if (zip.ContainsEntry("Data/Gui/IconMap.json"))
                        {
                            // ... and an actual icon map
                            if (zip.ContainsEntry("Data/Gui/IconMap.png"))
                            {
                                // Load all the points into the iconPoints dictionary
                                IDictionary<string, object> imDict = JsonConvert.DeserializeObject<ExpandoObject>(Zip.ReadText(zip["Data/Gui/IconMap.json"]));
                                Dictionary<Guid, Point> iconPoints = new Dictionary<Guid, Point>();

                                foreach (KeyValuePair<string, object> kvp in imDict)
                                {
                                    Guid itemUuid;
                                    if (Guid.TryParse(kvp.Key.ToString(), out itemUuid))
                                    {
                                        IDictionary<string, object> objDict = kvp.Value as IDictionary<string, object>;
                                        if (objDict.ContainsKey("x") && objDict.ContainsKey("y"))
                                        {
                                            int x, y;
                                            if (int.TryParse(objDict["x"].ToString(), out x))
                                                if (int.TryParse(objDict["y"].ToString(), out y))
                                                    iconPoints.Add(itemUuid, new Point(x, y));
                                        }
                                    }
                                }

                                // Open the icon map picture
                                using (CrcCalculatorStream stream = zip["Data/Gui/IconMap.png"].OpenReader())
                                {
                                    try
                                    {
                                        using (Image iconMapImage = Image.FromStream(stream))
                                        {
                                            using (Bitmap iconMapImg = new Bitmap(iconMapImage))
                                            {
                                                // And for every item without a (custom) icon the icon image; and make sure it won't be overwritten by a lower mod
                                                foreach (KeyValuePair<Guid, Point> kvp in iconPoints.Where((p) => !addedIcons.Contains(p.Key)))
                                                {
                                                    int x = kvp.Value.X, y = kvp.Value.Y;
                                                    Rectangle destination = new Rectangle(x, y, Math.Min(80, iconMapImg.Width - x), Math.Min(80, iconMapImg.Height - y));
                                                    Bitmap newIcon = iconMapImg.Clone(destination, iconMapImg.PixelFormat);
                                                    icons.Add(kvp.Key, newIcon);
                                                    addedIcons.Add(kvp.Key);
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(ex.Message + " Image data invalid.");
                                    }
                                }
                            }
                            else
                                throw new Exception("Mod provides IconMap.json but no IconMap.png");
                        }
                    }
                    pbPatch.Value = 45;

                    // Load resources
                    foreach (KeyValuePair<ModInfo, ZipFile> pair in modZipFiles)
                    {
                        foreach (ZipEntry entry in pair.Value.Entries)
                        {
                            // For every entry that is not a shapeset
                            if (entry.FileName.StartsWith("Data/") && !entry.FileName.Contains("/ShapeSets/") && !entry.FileName.EndsWith("/"))
                            {
                                switch (entry.FileName)
                                {
                                    // and also is not one of the files already read by
                                    case "Data/Objects/Database/physicsmaterials.json":
                                    case "Data/Objects/Database/basicmaterials.json":
                                    case "Data/Objects/Database/shapesets.json":
                                    case "Data/Objects/Database/rotationsets.json":
                                    case "Data/Gui/InventoryItemDescriptions.json":
                                    case "Data/Gui/IconMap.json":
                                        break;
                                    default:
                                        // Find file name for in Scrap Mechanic/Data
                                        string dataFileName = entry.FileName.Substring(5);

                                        // Read bytes from resource file if no higher mod adds this resource as well
                                        if (!resources.ContainsKey(dataFileName))
                                            using (BinaryReader r = new BinaryReader(entry.OpenReader()))
                                                resources[dataFileName] = r.ReadBytes((int)entry.UncompressedSize);
                                        break;
                                }
                            }
                        }
                    }
                    pbPatch.Value = 50;

                    // Write everything to the game directory
                    GameWriter writer = new GameWriter(Properties.Settings.Default.ScrapMechanicFolder);
                    
                    writer.WritePhysicsMaterials(materials);
                    pbPatch.Value = 60;
                    writer.WriteRotationSets(rotationSets);
                    pbPatch.Value = 70;
                    writer.WriteInventoryItemDescriptions(invItemDescs);
                    pbPatch.Value = 80;
                    writer.WriteBlocks(blocks);
                    pbPatch.Value = 85;
                    writer.WriteResources(resources);
                    pbPatch.Value = 90;
                    writer.WriteIcons(icons);
                    pbPatch.Value = 95;
                    writer.WriteShapesets(shapeSets);
                    pbPatch.Value = 100;

                    DialogResult r2 = MessageBox.Show("All " + this.Mods.Count + " mods are now installed. Do you want to start Scrap Mechanic to test it?", "Mods installed", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (r2 == System.Windows.Forms.DialogResult.Yes)
                    {
                        Process.Start("steam://rungameid/387990");
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("An exception occurred while loading the mods.\n\n" + ex.Message + "\n\n" + ex.Source + "\n\n" + ex.StackTrace, "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message + " on " + ex.Source);
                }
                finally
                {
                    foreach (ZipFile f in modZipFiles.Values)
                        f.Dispose();
                    
                    btnPatchGame.Enabled = false;
                }
            }
        }

        private void A_VerifyGCI(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("ScrapMechanic").Length != 0)
            {
                MessageBox.Show("You cannot install mods while the game is running. Please close it first.", "Please close Scrap Mechanic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbVerify.Value = 30;

            Process[] discordProcesses = Process.GetProcessesByName("Discord");
            bool stoppedDiscord = false;
            if (discordProcesses.Length != 0)
            {
                DialogResult r = MessageBox.Show("We've found that Discord is running at the moment. Would you like us to close Discord for a moment, because it conflicts with the verification process?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (r == DialogResult.Yes)
                {
                    stoppedDiscord = true;
                    foreach(Process p in discordProcesses)
                        p.Kill();
                }
            }

            MessageBox.Show("Steam will validate your game cache integrity. If it tells you to close all games and tools but you don't have any games or tools open, try restarting Steam first.", "Verify Game cache integrity", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // https://developer.valvesoftware.com/wiki/Steam_browser_protocol
            Process.Start("steam://validate/387990");
            pbVerify.Value = 60;

            if (stoppedDiscord)
            {
                DialogResult r3 = MessageBox.Show("Click OK to restart Discord.", "Restarted", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (r3 == DialogResult.OK)
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Discord\\Update.exe", "--processStart Discord.exe");
            }
            
            btnPatchGame.Enabled = true;
            pbPatch.Enabled = true;
            pbVerify.Value = 90;
        }
        #endregion

        #region General Form Event handlers
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shutdown();
        }

        private void installedModsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            LF_ModPanel();
        }

        private void M_RemoveCurrentMod(object sender, EventArgs e)
        {
            if (this.ModSelected)
            {
                DialogResult r = MessageBox.Show("Are you sure you want to remove " + this.CurrentMod.ModName + " by " + this.CurrentMod.AuthorName + "?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (r == DialogResult.Yes)
                {
                    this.RemoveMod(this.CurrentMod);
                    MessageBox.Show("The mod was successfully removed!", "Successfully removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LF_ModList();
                }
            }
        }

        private void M_AddMod(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Title = "Browse for .scrapmod file";
            d.Filter = "Scrap Mechanic .scrapmod|*.scrapmod";
            d.Multiselect = true;

            DialogResult r = d.ShowDialog();

            if (r == DialogResult.OK)
            {
                foreach (string fn in d.FileNames)
                    AddMod(fn);
            }
        }

        private void llblModURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.CurrentMod.ModURL.StartsWith("http://") || this.CurrentMod.ModURL.StartsWith("https://"))
                Process.Start(this.CurrentMod.ModURL);
        }

        private void llblAuthorURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.CurrentMod.AuthorURL.StartsWith("http://") || this.CurrentMod.AuthorURL.StartsWith("https://"))
                Process.Start(this.CurrentMod.AuthorURL);
        }

        private void H_BrowseMods(object sender, EventArgs e)
        {
            Process.Start("http://scrapcenter.net/mods");
        }

        private void S_OpenCreator(object sender, EventArgs e)
        {
            Process.Start("http://www.auxlux.com/creator");
        }


        private void btnModUp_Click(object sender, EventArgs e)
        {
            if (ModSelected)
            {
                ModInfo currentMod = this.CurrentMod;
                int currentModIndex = this.Mods.IndexOf(currentMod);
                if (currentModIndex != 0)
                {
                    this.Mods.Remove(currentMod);
                    this.Mods.Insert(currentModIndex - 1, currentMod);
                    LF_ModList();

                    this.lvInstalledMods.SelectedIndices.Add(currentModIndex - 1);
                }
            }
        }

        private void btnModDown_Click(object sender, EventArgs e)
        {
            if (ModSelected)
            {
                ModInfo currentMod = this.CurrentMod;
                int currentModIndex = this.Mods.IndexOf(currentMod);
                if (currentModIndex != (this.Mods.Count - 1))
                {
                    this.Mods.Remove(currentMod);
                    this.Mods.Insert(currentModIndex + 1, currentMod);
                    LF_ModList();

                    this.lvInstalledMods.SelectedIndices.Add(currentModIndex + 1);
                }
            }
        }


        private void B_WorldListChanged(object sender, EventArgs e)
        {
            bool selected = lvWorlds.SelectedIndices.Count == 1;
            btnGenerateBackup.Enabled = selected;
            btnExportBackup.Enabled = selected;
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text == "Search..." && tbSearch.ForeColor == Color.Gray)
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.Black;
            }
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                tbSearch.ForeColor = Color.Gray;
                tbSearch.Text = "Search...";
            }
        }
        #endregion

        #region Mod processing backend
        bool LoadMod(string path)
        {
            try
            {
                ZipFile zf = ZipFile.Read(path);
                string modInfoJsonText = "";
                Image modIcon = null;

                if (zf.ContainsEntry("modinfo.json"))
                    modInfoJsonText = Zip.ReadText(zf["modinfo.json"]);

                if (zf.ContainsEntry("modicon.png"))
                {
                    CrcCalculatorStream crc = zf["modicon.png"].OpenReader();
                    modIcon = Image.FromStream(crc);
                    crc.Close();
                }
                zf.Dispose();

                ModInfo modInfo = new ModInfo(path, modInfoJsonText, modIcon);

                if (!ModIDs.Contains(modInfo.ToString()))
                {
                    Mods.Add(modInfo);
                    ModIDs.Add(modInfo.ToString());
                    LF_ModList();
                    return true;
                }
                else
                {
                    this.latestException = new Exception("This mod is already loaded. If you want to update it, remove the old version first.");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                this.latestException = ex;
                return false;
            }
        }

        
        void AddMod(string fileName)
        {
            if (File.Exists(fileName))
            {
                FileInfo i = new FileInfo(fileName);
                string newFileName = Path.GetFileNameWithoutExtension(fileName);
                string nP = Path.Combine(this.ScrapMechanicFolder, "Scrapcenter", "Mods", newFileName + ".scrapmod");
                if (File.Exists(nP))
                {
                    FileInfo npI = new FileInfo(nP);
                    if (npI.FullName != i.FullName)
                    {
                        ModInfo q = null;
                        foreach (ModInfo mI in this.Mods)
                            if (mI.FileName.Equals(fileName))
                                q = mI;

                        if (q != null)
                        {
                            DialogResult r = MessageBox.Show("A mod already exists with this file name. Do you want to overwrite it?", "Confirm overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (r == DialogResult.Yes)
                                RemoveMod(q);
                            else
                                return;
                        }
                        else
                            File.Delete(nP);
                    }

                    if (File.Exists(nP))
                        File.Delete(nP);
                }

                File.Copy(fileName, nP);

                if (LoadMod(nP))
                {
                    MessageBox.Show("The mod was sucessfully added!", "Mod added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Could not load the mod. The following exception occurred:\n\n" + this.latestException.Message, "Mod error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("This mod does not exist or is not readable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void RemoveMod(ModInfo mod)
        {
            File.Delete(mod.FileName);
            this.Mods.Remove(mod);
            this.ModIDs.Remove(mod.ToString());
        }
        #endregion

        #region Drag N Drop
        private void DND_Enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                pnlDragNDrop.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void DND_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                AddMod(file);
            pnlDragNDrop.BorderStyle = BorderStyle.None;
        }

        private void DND_Leave(object sender, EventArgs e)
        {
            pnlDragNDrop.BorderStyle = BorderStyle.None;
        }
        #endregion

    }
}
