namespace Scrapcenter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "World",
            "Today, 15:58",
            "Yesterday, 12:32"}, -1);
            this.header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuBar = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.menuBtnBackups = new System.Windows.Forms.Label();
            this.menuBtnTutorials = new System.Windows.Forms.Label();
            this.menuBtnSkins = new System.Windows.Forms.Label();
            this.menuBtnMods = new System.Windows.Forms.Label();
            this.menuBtnHome = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Panel();
            this.mainPanelSkins = new System.Windows.Forms.Panel();
            this.lblInfoSkins = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSkindexAvailableSoon = new System.Windows.Forms.Label();
            this.mainPanelMods = new System.Windows.Forms.Panel();
            this.pblDropModsWrapper = new System.Windows.Forms.Panel();
            this.pnlDragNDrop = new System.Windows.Forms.Panel();
            this.pnlPatchStatus = new System.Windows.Forms.Panel();
            this.pbPatch = new System.Windows.Forms.ProgressBar();
            this.pbVerify = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.btnPatchGame = new System.Windows.Forms.Button();
            this.pnlModsLeft = new System.Windows.Forms.Panel();
            this.lvInstalledMods = new System.Windows.Forms.ListView();
            this.modLogoImageList = new System.Windows.Forms.ImageList(this.components);
            this.pnlCurModInfo = new System.Windows.Forms.Panel();
            this.lblModCopyright = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.llblModURL = new System.Windows.Forms.LinkLabel();
            this.lblListRequiredMods = new System.Windows.Forms.Label();
            this.lblListRequiredModsCaption = new System.Windows.Forms.Label();
            this.lblLoaderVersion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblGameVersion = new System.Windows.Forms.Label();
            this.llblAuthorURL = new System.Windows.Forms.LinkLabel();
            this.lblModVersion = new System.Windows.Forms.Label();
            this.pbModIcon = new System.Windows.Forms.PictureBox();
            this.lblModName = new System.Windows.Forms.Label();
            this.btnModUp = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnModDown = new System.Windows.Forms.Button();
            this.mainPanelBackups = new System.Windows.Forms.Panel();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.lblHideBackups = new System.Windows.Forms.Label();
            this.btnManageBackups = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExportBackup = new System.Windows.Forms.Button();
            this.btnImportBackup = new System.Windows.Forms.Button();
            this.btnGenerateBackup = new System.Windows.Forms.Button();
            this.lvWorlds = new System.Windows.Forms.ListView();
            this.chWorldName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLatestBackup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainPanelHome = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlRecentBlogPosts = new System.Windows.Forms.Panel();
            this.wbBlog = new System.Windows.Forms.WebBrowser();
            this.mainPanelTutorials = new System.Windows.Forms.Panel();
            this.ttContributors = new System.Windows.Forms.ToolTip(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuBar.SuspendLayout();
            this.content.SuspendLayout();
            this.mainPanelSkins.SuspendLayout();
            this.mainPanelMods.SuspendLayout();
            this.pblDropModsWrapper.SuspendLayout();
            this.pnlPatchStatus.SuspendLayout();
            this.pnlModsLeft.SuspendLayout();
            this.pnlCurModInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbModIcon)).BeginInit();
            this.mainPanelBackups.SuspendLayout();
            this.mainPanelHome.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlRecentBlogPosts.SuspendLayout();
            this.mainPanelTutorials.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(19)))), ((int)(((byte)(29)))));
            this.header.Controls.Add(this.label1);
            this.header.Controls.Add(this.pictureBox1);
            this.header.Controls.Add(this.menuBar);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.ForeColor = System.Drawing.Color.White;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1346, 126);
            this.header.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scrapcenter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(73)))));
            this.menuBar.Controls.Add(this.tbSearch);
            this.menuBar.Controls.Add(this.menuBtnBackups);
            this.menuBar.Controls.Add(this.menuBtnTutorials);
            this.menuBar.Controls.Add(this.menuBtnSkins);
            this.menuBar.Controls.Add(this.menuBtnMods);
            this.menuBar.Controls.Add(this.menuBtnHome);
            this.menuBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBar.Location = new System.Drawing.Point(0, 78);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1346, 48);
            this.menuBar.TabIndex = 0;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.ForeColor = System.Drawing.Color.Gray;
            this.tbSearch.Location = new System.Drawing.Point(1134, 11);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(200, 24);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.Text = "Search...";
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // menuBtnBackups
            // 
            this.menuBtnBackups.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuBtnBackups.Location = new System.Drawing.Point(594, 0);
            this.menuBtnBackups.Name = "menuBtnBackups";
            this.menuBtnBackups.Size = new System.Drawing.Size(156, 48);
            this.menuBtnBackups.TabIndex = 10;
            this.menuBtnBackups.Text = "Backups";
            this.menuBtnBackups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuBtnBackups.Click += new System.EventHandler(this.MPL_Backups);
            // 
            // menuBtnTutorials
            // 
            this.menuBtnTutorials.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuBtnTutorials.Location = new System.Drawing.Point(438, 0);
            this.menuBtnTutorials.Name = "menuBtnTutorials";
            this.menuBtnTutorials.Size = new System.Drawing.Size(156, 48);
            this.menuBtnTutorials.TabIndex = 9;
            this.menuBtnTutorials.Text = "Tutorials";
            this.menuBtnTutorials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuBtnTutorials.Click += new System.EventHandler(this.MPL_Tutorials);
            // 
            // menuBtnSkins
            // 
            this.menuBtnSkins.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuBtnSkins.Location = new System.Drawing.Point(315, 0);
            this.menuBtnSkins.Name = "menuBtnSkins";
            this.menuBtnSkins.Size = new System.Drawing.Size(123, 48);
            this.menuBtnSkins.TabIndex = 8;
            this.menuBtnSkins.Text = "Skins";
            this.menuBtnSkins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuBtnSkins.Click += new System.EventHandler(this.MPL_Skins);
            // 
            // menuBtnMods
            // 
            this.menuBtnMods.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuBtnMods.Location = new System.Drawing.Point(159, 0);
            this.menuBtnMods.Name = "menuBtnMods";
            this.menuBtnMods.Size = new System.Drawing.Size(156, 48);
            this.menuBtnMods.TabIndex = 7;
            this.menuBtnMods.Text = "Mods";
            this.menuBtnMods.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuBtnMods.Click += new System.EventHandler(this.MPL_Mods);
            // 
            // menuBtnHome
            // 
            this.menuBtnHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuBtnHome.Location = new System.Drawing.Point(0, 0);
            this.menuBtnHome.Name = "menuBtnHome";
            this.menuBtnHome.Size = new System.Drawing.Size(159, 48);
            this.menuBtnHome.TabIndex = 6;
            this.menuBtnHome.Text = "Home";
            this.menuBtnHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuBtnHome.Click += new System.EventHandler(this.MPL_Home);
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.content.Controls.Add(this.mainPanelTutorials);
            this.content.Controls.Add(this.mainPanelSkins);
            this.content.Controls.Add(this.mainPanelMods);
            this.content.Controls.Add(this.mainPanelBackups);
            this.content.Controls.Add(this.mainPanelHome);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 126);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1346, 519);
            this.content.TabIndex = 1;
            // 
            // mainPanelSkins
            // 
            this.mainPanelSkins.Controls.Add(this.lblInfoSkins);
            this.mainPanelSkins.Controls.Add(this.button2);
            this.mainPanelSkins.Controls.Add(this.lblSkindexAvailableSoon);
            this.mainPanelSkins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelSkins.Location = new System.Drawing.Point(0, 0);
            this.mainPanelSkins.Name = "mainPanelSkins";
            this.mainPanelSkins.Size = new System.Drawing.Size(1346, 519);
            this.mainPanelSkins.TabIndex = 1;
            // 
            // lblInfoSkins
            // 
            this.lblInfoSkins.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoSkins.Location = new System.Drawing.Point(494, 57);
            this.lblInfoSkins.Name = "lblInfoSkins";
            this.lblInfoSkins.Size = new System.Drawing.Size(318, 57);
            this.lblInfoSkins.TabIndex = 3;
            this.lblInfoSkins.Text = "Skins can be installed after mods have been installed, by following the instructi" +
    "ons on the Skin Creator page.";
            this.lblInfoSkins.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(496, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(316, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "Open AuxLux\' Skin Creator";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.S_OpenCreator);
            // 
            // lblSkindexAvailableSoon
            // 
            this.lblSkindexAvailableSoon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSkindexAvailableSoon.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkindexAvailableSoon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSkindexAvailableSoon.Location = new System.Drawing.Point(0, 114);
            this.lblSkindexAvailableSoon.Name = "lblSkindexAvailableSoon";
            this.lblSkindexAvailableSoon.Size = new System.Drawing.Size(1346, 405);
            this.lblSkindexAvailableSoon.TabIndex = 0;
            this.lblSkindexAvailableSoon.Text = "The skindex is still under development, and will be available as soon as possible" +
    "!";
            this.lblSkindexAvailableSoon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanelMods
            // 
            this.mainPanelMods.Controls.Add(this.pblDropModsWrapper);
            this.mainPanelMods.Controls.Add(this.pnlPatchStatus);
            this.mainPanelMods.Controls.Add(this.pnlModsLeft);
            this.mainPanelMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelMods.Location = new System.Drawing.Point(0, 0);
            this.mainPanelMods.Name = "mainPanelMods";
            this.mainPanelMods.Size = new System.Drawing.Size(1346, 519);
            this.mainPanelMods.TabIndex = 1;
            // 
            // pblDropModsWrapper
            // 
            this.pblDropModsWrapper.Controls.Add(this.pnlDragNDrop);
            this.pblDropModsWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pblDropModsWrapper.Location = new System.Drawing.Point(403, 0);
            this.pblDropModsWrapper.Name = "pblDropModsWrapper";
            this.pblDropModsWrapper.Size = new System.Drawing.Size(765, 519);
            this.pblDropModsWrapper.TabIndex = 13;
            // 
            // pnlDragNDrop
            // 
            this.pnlDragNDrop.AllowDrop = true;
            this.pnlDragNDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.pnlDragNDrop.BackgroundImage = global::Scrapcenter.Properties.Resources.browsemod;
            this.pnlDragNDrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlDragNDrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDragNDrop.Location = new System.Drawing.Point(0, 0);
            this.pnlDragNDrop.Name = "pnlDragNDrop";
            this.pnlDragNDrop.Size = new System.Drawing.Size(765, 519);
            this.pnlDragNDrop.TabIndex = 10;
            this.pnlDragNDrop.Click += new System.EventHandler(this.M_AddMod);
            this.pnlDragNDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.DND_Drop);
            this.pnlDragNDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.DND_Enter);
            this.pnlDragNDrop.DragLeave += new System.EventHandler(this.DND_Leave);
            // 
            // pnlPatchStatus
            // 
            this.pnlPatchStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlPatchStatus.Controls.Add(this.pbPatch);
            this.pnlPatchStatus.Controls.Add(this.pbVerify);
            this.pnlPatchStatus.Controls.Add(this.label6);
            this.pnlPatchStatus.Controls.Add(this.label3);
            this.pnlPatchStatus.Controls.Add(this.button5);
            this.pnlPatchStatus.Controls.Add(this.btnPatchGame);
            this.pnlPatchStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPatchStatus.Location = new System.Drawing.Point(1168, 0);
            this.pnlPatchStatus.Name = "pnlPatchStatus";
            this.pnlPatchStatus.Size = new System.Drawing.Size(178, 519);
            this.pnlPatchStatus.TabIndex = 20;
            // 
            // pbPatch
            // 
            this.pbPatch.Enabled = false;
            this.pbPatch.Location = new System.Drawing.Point(28, 107);
            this.pbPatch.Name = "pbPatch";
            this.pbPatch.Size = new System.Drawing.Size(147, 16);
            this.pbPatch.TabIndex = 13;
            // 
            // pbVerify
            // 
            this.pbVerify.Location = new System.Drawing.Point(28, 44);
            this.pbVerify.MarqueeAnimationSpeed = 200;
            this.pbVerify.Maximum = 90;
            this.pbVerify.Name = "pbVerify";
            this.pbVerify.Size = new System.Drawing.Size(147, 16);
            this.pbVerify.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "2.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "1.";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(28, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 35);
            this.button5.TabIndex = 9;
            this.button5.Text = "Verify integrity";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.A_VerifyGCI);
            // 
            // btnPatchGame
            // 
            this.btnPatchGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatchGame.Enabled = false;
            this.btnPatchGame.Location = new System.Drawing.Point(28, 66);
            this.btnPatchGame.Name = "btnPatchGame";
            this.btnPatchGame.Size = new System.Drawing.Size(147, 35);
            this.btnPatchGame.TabIndex = 8;
            this.btnPatchGame.Text = "Patch game";
            this.btnPatchGame.UseVisualStyleBackColor = true;
            this.btnPatchGame.Click += new System.EventHandler(this.A_PatchGame);
            // 
            // pnlModsLeft
            // 
            this.pnlModsLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlModsLeft.Controls.Add(this.lvInstalledMods);
            this.pnlModsLeft.Controls.Add(this.pnlCurModInfo);
            this.pnlModsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlModsLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlModsLeft.Name = "pnlModsLeft";
            this.pnlModsLeft.Size = new System.Drawing.Size(403, 519);
            this.pnlModsLeft.TabIndex = 19;
            // 
            // lvInstalledMods
            // 
            this.lvInstalledMods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvInstalledMods.HideSelection = false;
            this.lvInstalledMods.Location = new System.Drawing.Point(3, 3);
            this.lvInstalledMods.MultiSelect = false;
            this.lvInstalledMods.Name = "lvInstalledMods";
            this.lvInstalledMods.Size = new System.Drawing.Size(182, 513);
            this.lvInstalledMods.SmallImageList = this.modLogoImageList;
            this.lvInstalledMods.TabIndex = 1;
            this.lvInstalledMods.UseCompatibleStateImageBehavior = false;
            this.lvInstalledMods.View = System.Windows.Forms.View.List;
            this.lvInstalledMods.SelectedIndexChanged += new System.EventHandler(this.installedModsView_SelectedIndexChanged);
            // 
            // modLogoImageList
            // 
            this.modLogoImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.modLogoImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.modLogoImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlCurModInfo
            // 
            this.pnlCurModInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCurModInfo.BackColor = System.Drawing.Color.White;
            this.pnlCurModInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCurModInfo.Controls.Add(this.lblModCopyright);
            this.pnlCurModInfo.Controls.Add(this.lblAuthor);
            this.pnlCurModInfo.Controls.Add(this.llblModURL);
            this.pnlCurModInfo.Controls.Add(this.lblListRequiredMods);
            this.pnlCurModInfo.Controls.Add(this.lblListRequiredModsCaption);
            this.pnlCurModInfo.Controls.Add(this.lblLoaderVersion);
            this.pnlCurModInfo.Controls.Add(this.label10);
            this.pnlCurModInfo.Controls.Add(this.label9);
            this.pnlCurModInfo.Controls.Add(this.lblGameVersion);
            this.pnlCurModInfo.Controls.Add(this.llblAuthorURL);
            this.pnlCurModInfo.Controls.Add(this.lblModVersion);
            this.pnlCurModInfo.Controls.Add(this.pbModIcon);
            this.pnlCurModInfo.Controls.Add(this.lblModName);
            this.pnlCurModInfo.Controls.Add(this.btnModUp);
            this.pnlCurModInfo.Controls.Add(this.button3);
            this.pnlCurModInfo.Controls.Add(this.btnModDown);
            this.pnlCurModInfo.Location = new System.Drawing.Point(184, 3);
            this.pnlCurModInfo.Name = "pnlCurModInfo";
            this.pnlCurModInfo.Size = new System.Drawing.Size(216, 513);
            this.pnlCurModInfo.TabIndex = 4;
            this.pnlCurModInfo.Visible = false;
            // 
            // lblModCopyright
            // 
            this.lblModCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModCopyright.Location = new System.Drawing.Point(6, 396);
            this.lblModCopyright.Name = "lblModCopyright";
            this.lblModCopyright.Size = new System.Drawing.Size(198, 65);
            this.lblModCopyright.TabIndex = 19;
            this.lblModCopyright.Text = "Please remember copyright belongs to all repsective authors. Distributing this mo" +
    "d without the authors permission is not allowed.";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(72, 51);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(55, 16);
            this.lblAuthor.TabIndex = 18;
            this.lblAuthor.Text = "{author}";
            // 
            // llblModURL
            // 
            this.llblModURL.AutoSize = true;
            this.llblModURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.llblModURL.Location = new System.Drawing.Point(72, 35);
            this.llblModURL.Name = "llblModURL";
            this.llblModURL.Size = new System.Drawing.Size(58, 16);
            this.llblModURL.TabIndex = 17;
            this.llblModURL.TabStop = true;
            this.llblModURL.Text = "Website";
            this.llblModURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblModURL_LinkClicked);
            // 
            // lblListRequiredMods
            // 
            this.lblListRequiredMods.AutoSize = true;
            this.lblListRequiredMods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListRequiredMods.ForeColor = System.Drawing.Color.Maroon;
            this.lblListRequiredMods.Location = new System.Drawing.Point(6, 220);
            this.lblListRequiredMods.Name = "lblListRequiredMods";
            this.lblListRequiredMods.Size = new System.Drawing.Size(128, 16);
            this.lblListRequiredMods.TabIndex = 16;
            this.lblListRequiredMods.Text = "{#list:requiredMods}";
            // 
            // lblListRequiredModsCaption
            // 
            this.lblListRequiredModsCaption.AutoSize = true;
            this.lblListRequiredModsCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListRequiredModsCaption.Location = new System.Drawing.Point(6, 204);
            this.lblListRequiredModsCaption.Name = "lblListRequiredModsCaption";
            this.lblListRequiredModsCaption.Size = new System.Drawing.Size(198, 16);
            this.lblListRequiredModsCaption.TabIndex = 15;
            this.lblListRequiredModsCaption.Text = "Additionally required  mods";
            // 
            // lblLoaderVersion
            // 
            this.lblLoaderVersion.AutoSize = true;
            this.lblLoaderVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaderVersion.Location = new System.Drawing.Point(6, 165);
            this.lblLoaderVersion.Name = "lblLoaderVersion";
            this.lblLoaderVersion.Size = new System.Drawing.Size(116, 16);
            this.lblLoaderVersion.TabIndex = 14;
            this.lblLoaderVersion.Text = "v. {loaderVersion}";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Loader version";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Game version";
            // 
            // lblGameVersion
            // 
            this.lblGameVersion.AutoSize = true;
            this.lblGameVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameVersion.Location = new System.Drawing.Point(6, 110);
            this.lblGameVersion.Name = "lblGameVersion";
            this.lblGameVersion.Size = new System.Drawing.Size(112, 16);
            this.lblGameVersion.TabIndex = 9;
            this.lblGameVersion.Text = "v. {gameVersion}";
            // 
            // llblAuthorURL
            // 
            this.llblAuthorURL.AutoSize = true;
            this.llblAuthorURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.llblAuthorURL.Location = new System.Drawing.Point(72, 51);
            this.llblAuthorURL.Name = "llblAuthorURL";
            this.llblAuthorURL.Size = new System.Drawing.Size(55, 16);
            this.llblAuthorURL.TabIndex = 8;
            this.llblAuthorURL.TabStop = true;
            this.llblAuthorURL.Text = "{author}";
            this.llblAuthorURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAuthorURL_LinkClicked);
            // 
            // lblModVersion
            // 
            this.lblModVersion.AutoSize = true;
            this.lblModVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModVersion.Location = new System.Drawing.Point(72, 19);
            this.lblModVersion.Name = "lblModVersion";
            this.lblModVersion.Size = new System.Drawing.Size(75, 16);
            this.lblModVersion.TabIndex = 7;
            this.lblModVersion.Text = "v. {version}";
            // 
            // pbModIcon
            // 
            this.pbModIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbModIcon.Image")));
            this.pbModIcon.Location = new System.Drawing.Point(3, 3);
            this.pbModIcon.Name = "pbModIcon";
            this.pbModIcon.Size = new System.Drawing.Size(64, 64);
            this.pbModIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbModIcon.TabIndex = 2;
            this.pbModIcon.TabStop = false;
            // 
            // lblModName
            // 
            this.lblModName.AutoSize = true;
            this.lblModName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModName.Location = new System.Drawing.Point(72, 3);
            this.lblModName.Name = "lblModName";
            this.lblModName.Size = new System.Drawing.Size(91, 16);
            this.lblModName.TabIndex = 3;
            this.lblModName.Text = "{modName}";
            // 
            // btnModUp
            // 
            this.btnModUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModUp.Location = new System.Drawing.Point(6, 468);
            this.btnModUp.Name = "btnModUp";
            this.btnModUp.Size = new System.Drawing.Size(47, 40);
            this.btnModUp.TabIndex = 4;
            this.btnModUp.Text = "Λ";
            this.btnModUp.UseVisualStyleBackColor = true;
            this.btnModUp.Click += new System.EventHandler(this.btnModUp_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(164, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 40);
            this.button3.TabIndex = 6;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.M_RemoveCurrentMod);
            // 
            // btnModDown
            // 
            this.btnModDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModDown.Location = new System.Drawing.Point(59, 468);
            this.btnModDown.Name = "btnModDown";
            this.btnModDown.Size = new System.Drawing.Size(47, 40);
            this.btnModDown.TabIndex = 5;
            this.btnModDown.Text = "V";
            this.btnModDown.UseVisualStyleBackColor = true;
            this.btnModDown.Click += new System.EventHandler(this.btnModDown_Click);
            // 
            // mainPanelBackups
            // 
            this.mainPanelBackups.Controls.Add(this.cbUsers);
            this.mainPanelBackups.Controls.Add(this.lblHideBackups);
            this.mainPanelBackups.Controls.Add(this.btnManageBackups);
            this.mainPanelBackups.Controls.Add(this.label11);
            this.mainPanelBackups.Controls.Add(this.label12);
            this.mainPanelBackups.Controls.Add(this.label8);
            this.mainPanelBackups.Controls.Add(this.label7);
            this.mainPanelBackups.Controls.Add(this.btnExportBackup);
            this.mainPanelBackups.Controls.Add(this.btnImportBackup);
            this.mainPanelBackups.Controls.Add(this.btnGenerateBackup);
            this.mainPanelBackups.Controls.Add(this.lvWorlds);
            this.mainPanelBackups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelBackups.Location = new System.Drawing.Point(0, 0);
            this.mainPanelBackups.Name = "mainPanelBackups";
            this.mainPanelBackups.Size = new System.Drawing.Size(1346, 519);
            this.mainPanelBackups.TabIndex = 2;
            // 
            // cbUsers
            // 
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(3, 6);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(393, 21);
            this.cbUsers.TabIndex = 11;
            // 
            // lblHideBackups
            // 
            this.lblHideBackups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHideBackups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblHideBackups.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHideBackups.Location = new System.Drawing.Point(0, 388);
            this.lblHideBackups.Name = "lblHideBackups";
            this.lblHideBackups.Size = new System.Drawing.Size(1345, 131);
            this.lblHideBackups.TabIndex = 10;
            this.lblHideBackups.Text = "The backup functionality has not yet been implemented, but we wanted to give you " +
    "a small look at what\'s coming!";
            this.lblHideBackups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnManageBackups
            // 
            this.btnManageBackups.Enabled = false;
            this.btnManageBackups.Location = new System.Drawing.Point(409, 71);
            this.btnManageBackups.Name = "btnManageBackups";
            this.btnManageBackups.Size = new System.Drawing.Size(218, 26);
            this.btnManageBackups.TabIndex = 9;
            this.btnManageBackups.Text = "Manage backups";
            this.btnManageBackups.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(740, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(573, 234);
            this.label11.TabIndex = 8;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(739, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(231, 24);
            this.label12.TabIndex = 7;
            this.label12.Text = "How can I make backups?";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(740, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(573, 125);
            this.label8.TabIndex = 6;
            this.label8.Text = "A backup is an older version of a world. It\'s good to keep backups of your worlds" +
    ", because when you accidentally destroy it or someone griefs you, you can restor" +
    "e the world to a previous state.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(739, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "What are backups?";
            // 
            // btnExportBackup
            // 
            this.btnExportBackup.Enabled = false;
            this.btnExportBackup.Location = new System.Drawing.Point(409, 162);
            this.btnExportBackup.Name = "btnExportBackup";
            this.btnExportBackup.Size = new System.Drawing.Size(218, 26);
            this.btnExportBackup.TabIndex = 4;
            this.btnExportBackup.Text = "Export backup";
            this.btnExportBackup.UseVisualStyleBackColor = true;
            // 
            // btnImportBackup
            // 
            this.btnImportBackup.Location = new System.Drawing.Point(409, 130);
            this.btnImportBackup.Name = "btnImportBackup";
            this.btnImportBackup.Size = new System.Drawing.Size(218, 26);
            this.btnImportBackup.TabIndex = 3;
            this.btnImportBackup.Text = "Import backup";
            this.btnImportBackup.UseVisualStyleBackColor = true;
            // 
            // btnGenerateBackup
            // 
            this.btnGenerateBackup.Enabled = false;
            this.btnGenerateBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBackup.Location = new System.Drawing.Point(409, 39);
            this.btnGenerateBackup.Name = "btnGenerateBackup";
            this.btnGenerateBackup.Size = new System.Drawing.Size(218, 26);
            this.btnGenerateBackup.TabIndex = 1;
            this.btnGenerateBackup.Text = "Generate backup";
            this.btnGenerateBackup.UseVisualStyleBackColor = true;
            // 
            // lvWorlds
            // 
            this.lvWorlds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWorldName,
            this.chLastModified,
            this.chLatestBackup});
            this.lvWorlds.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvWorlds.Location = new System.Drawing.Point(3, 39);
            this.lvWorlds.Name = "lvWorlds";
            this.lvWorlds.Size = new System.Drawing.Size(393, 477);
            this.lvWorlds.TabIndex = 0;
            this.lvWorlds.UseCompatibleStateImageBehavior = false;
            this.lvWorlds.View = System.Windows.Forms.View.Details;
            this.lvWorlds.SelectedIndexChanged += new System.EventHandler(this.B_WorldListChanged);
            // 
            // chWorldName
            // 
            this.chWorldName.Text = "World name";
            this.chWorldName.Width = 107;
            // 
            // chLastModified
            // 
            this.chLastModified.Text = "Played";
            this.chLastModified.Width = 92;
            // 
            // chLatestBackup
            // 
            this.chLatestBackup.Text = "Latest backup";
            this.chLatestBackup.Width = 189;
            // 
            // mainPanelHome
            // 
            this.mainPanelHome.Controls.Add(this.panel2);
            this.mainPanelHome.Controls.Add(this.pnlRecentBlogPosts);
            this.mainPanelHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelHome.Location = new System.Drawing.Point(0, 0);
            this.mainPanelHome.Name = "mainPanelHome";
            this.mainPanelHome.Size = new System.Drawing.Size(1346, 519);
            this.mainPanelHome.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(544, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 519);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(783, 278);
            this.label5.TabIndex = 5;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(10, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(780, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Browse mods on the internet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.H_BrowseMods);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(793, 52);
            this.label2.TabIndex = 0;
            this.label2.Text = "Scrapcenter is still under development";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRecentBlogPosts
            // 
            this.pnlRecentBlogPosts.BackColor = System.Drawing.Color.White;
            this.pnlRecentBlogPosts.Controls.Add(this.wbBlog);
            this.pnlRecentBlogPosts.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRecentBlogPosts.Location = new System.Drawing.Point(0, 0);
            this.pnlRecentBlogPosts.Name = "pnlRecentBlogPosts";
            this.pnlRecentBlogPosts.Size = new System.Drawing.Size(544, 519);
            this.pnlRecentBlogPosts.TabIndex = 2;
            // 
            // wbBlog
            // 
            this.wbBlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbBlog.Location = new System.Drawing.Point(0, 0);
            this.wbBlog.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBlog.Name = "wbBlog";
            this.wbBlog.Size = new System.Drawing.Size(544, 519);
            this.wbBlog.TabIndex = 1;
            this.wbBlog.Url = new System.Uri("http://scrapcenter.net/blog/cleanview", System.UriKind.Absolute);
            // 
            // mainPanelTutorials
            // 
            this.mainPanelTutorials.Controls.Add(this.webBrowser1);
            this.mainPanelTutorials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelTutorials.Location = new System.Drawing.Point(0, 0);
            this.mainPanelTutorials.Name = "mainPanelTutorials";
            this.mainPanelTutorials.Size = new System.Drawing.Size(1346, 519);
            this.mainPanelTutorials.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1346, 519);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("http://www.scrapcenter.net/clean/tutorials", System.UriKind.Absolute);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 645);
            this.Controls.Add(this.content);
            this.Controls.Add(this.header);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 450);
            this.Name = "MainWindow";
            this.Text = "Scrapcenter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.content.ResumeLayout(false);
            this.mainPanelSkins.ResumeLayout(false);
            this.mainPanelMods.ResumeLayout(false);
            this.pblDropModsWrapper.ResumeLayout(false);
            this.pnlPatchStatus.ResumeLayout(false);
            this.pnlPatchStatus.PerformLayout();
            this.pnlModsLeft.ResumeLayout(false);
            this.pnlCurModInfo.ResumeLayout(false);
            this.pnlCurModInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbModIcon)).EndInit();
            this.mainPanelBackups.ResumeLayout(false);
            this.mainPanelBackups.PerformLayout();
            this.mainPanelHome.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlRecentBlogPosts.ResumeLayout(false);
            this.mainPanelTutorials.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel menuBar;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label menuBtnTutorials;
        private System.Windows.Forms.Label menuBtnSkins;
        private System.Windows.Forms.Label menuBtnMods;
        private System.Windows.Forms.Label menuBtnHome;
        private System.Windows.Forms.Panel mainPanelTutorials;
        private System.Windows.Forms.Panel mainPanelMods;
        private System.Windows.Forms.Panel mainPanelSkins;
        private System.Windows.Forms.Panel mainPanelHome;
        private System.Windows.Forms.Label lblSkindexAvailableSoon;
        private System.Windows.Forms.Label menuBtnBackups;
        private System.Windows.Forms.Panel mainPanelBackups;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel pnlCurModInfo;
        private System.Windows.Forms.PictureBox pbModIcon;
        private System.Windows.Forms.Label lblModName;
        private System.Windows.Forms.ListView lvInstalledMods;
        private System.Windows.Forms.ImageList modLogoImageList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnModDown;
        private System.Windows.Forms.Button btnModUp;
        private System.Windows.Forms.Button btnPatchGame;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblListRequiredMods;
        private System.Windows.Forms.Label lblListRequiredModsCaption;
        private System.Windows.Forms.Label lblLoaderVersion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblGameVersion;
        private System.Windows.Forms.LinkLabel llblAuthorURL;
        private System.Windows.Forms.Label lblModVersion;
        private System.Windows.Forms.Panel pnlDragNDrop;
        private System.Windows.Forms.LinkLabel llblModURL;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Panel pblDropModsWrapper;
        private System.Windows.Forms.Panel pnlPatchStatus;
        private System.Windows.Forms.Panel pnlModsLeft;
        private System.Windows.Forms.ProgressBar pbPatch;
        private System.Windows.Forms.ProgressBar pbVerify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.WebBrowser wbBlog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlRecentBlogPosts;
        private System.Windows.Forms.Button btnManageBackups;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExportBackup;
        private System.Windows.Forms.Button btnImportBackup;
        private System.Windows.Forms.Button btnGenerateBackup;
        private System.Windows.Forms.ListView lvWorlds;
        private System.Windows.Forms.ColumnHeader chWorldName;
        private System.Windows.Forms.ColumnHeader chLastModified;
        private System.Windows.Forms.ColumnHeader chLatestBackup;
        private System.Windows.Forms.Label lblHideBackups;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.ToolTip ttContributors;
        private System.Windows.Forms.Label lblModCopyright;
        private System.Windows.Forms.Label lblInfoSkins;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

