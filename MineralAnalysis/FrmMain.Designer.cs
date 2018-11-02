namespace MineralAnalysis
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuBtnImageNewTab = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuBtnLoadImageCurrentTab = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuBtnCloseCurrentTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBarSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.sbLabelReady = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.sbLabelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabelImagePosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabelImageSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabelImageScrollPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabelImageZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuMain.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1420, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuBtnImageNewTab,
            this.mainMenuBtnLoadImageCurrentTab,
            this.mainMenuBtnCloseCurrentTab,
            this.menuBarSeparator1,
            this.btnMainMenuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mainMenuBtnImageNewTab
            // 
            this.mainMenuBtnImageNewTab.Image = global::MineralAnalysis.Properties.Resources.import_export16x16;
            this.mainMenuBtnImageNewTab.Name = "mainMenuBtnImageNewTab";
            this.mainMenuBtnImageNewTab.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.mainMenuBtnImageNewTab.Size = new System.Drawing.Size(268, 22);
            this.mainMenuBtnImageNewTab.Text = "&Load Image (New Tab)";
            this.mainMenuBtnImageNewTab.Click += new System.EventHandler(this.EventClick);
            // 
            // mainMenuBtnLoadImageCurrentTab
            // 
            this.mainMenuBtnLoadImageCurrentTab.Enabled = false;
            this.mainMenuBtnLoadImageCurrentTab.Image = global::MineralAnalysis.Properties.Resources.import_export16x16;
            this.mainMenuBtnLoadImageCurrentTab.Name = "mainMenuBtnLoadImageCurrentTab";
            this.mainMenuBtnLoadImageCurrentTab.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mainMenuBtnLoadImageCurrentTab.Size = new System.Drawing.Size(268, 22);
            this.mainMenuBtnLoadImageCurrentTab.Text = "&Load Image (Current Tab)";
            this.mainMenuBtnLoadImageCurrentTab.Click += new System.EventHandler(this.EventClick);
            // 
            // mainMenuBtnCloseCurrentTab
            // 
            this.mainMenuBtnCloseCurrentTab.Enabled = false;
            this.mainMenuBtnCloseCurrentTab.Image = global::MineralAnalysis.Properties.Resources.tab_close16x16;
            this.mainMenuBtnCloseCurrentTab.Name = "mainMenuBtnCloseCurrentTab";
            this.mainMenuBtnCloseCurrentTab.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mainMenuBtnCloseCurrentTab.Size = new System.Drawing.Size(268, 22);
            this.mainMenuBtnCloseCurrentTab.Text = "Close current tab";
            this.mainMenuBtnCloseCurrentTab.Click += new System.EventHandler(this.EventClick);
            // 
            // menuBarSeparator1
            // 
            this.menuBarSeparator1.Name = "menuBarSeparator1";
            this.menuBarSeparator1.Size = new System.Drawing.Size(265, 6);
            // 
            // btnMainMenuExit
            // 
            this.btnMainMenuExit.Image = global::MineralAnalysis.Properties.Resources.shutdown16x16;
            this.btnMainMenuExit.Name = "btnMainMenuExit";
            this.btnMainMenuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.btnMainMenuExit.Size = new System.Drawing.Size(268, 22);
            this.btnMainMenuExit.Text = "E&xit";
            this.btnMainMenuExit.Click += new System.EventHandler(this.EventClick);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabelReady,
            this.sbProgress,
            this.sbLabelSpring,
            this.sbLabelImagePosition,
            this.sbLabelImageSize,
            this.sbLabelImageScrollPosition,
            this.sbLabelImageZoom});
            this.statusBar.Location = new System.Drawing.Point(0, 804);
            this.statusBar.Name = "statusBar";
            this.statusBar.ShowItemToolTips = true;
            this.statusBar.Size = new System.Drawing.Size(1420, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "Status Bar";
            // 
            // sbLabelReady
            // 
            this.sbLabelReady.Name = "sbLabelReady";
            this.sbLabelReady.Size = new System.Drawing.Size(39, 17);
            this.sbLabelReady.Text = "Ready";
            // 
            // sbProgress
            // 
            this.sbProgress.MarqueeAnimationSpeed = 30;
            this.sbProgress.Name = "sbProgress";
            this.sbProgress.Size = new System.Drawing.Size(200, 16);
            this.sbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.sbProgress.Visible = false;
            // 
            // sbLabelSpring
            // 
            this.sbLabelSpring.Name = "sbLabelSpring";
            this.sbLabelSpring.Size = new System.Drawing.Size(794, 17);
            this.sbLabelSpring.Spring = true;
            // 
            // sbLabelImagePosition
            // 
            this.sbLabelImagePosition.Image = global::MineralAnalysis.Properties.Resources.cursor16x16;
            this.sbLabelImagePosition.Name = "sbLabelImagePosition";
            this.sbLabelImagePosition.Size = new System.Drawing.Size(107, 17);
            this.sbLabelImagePosition.Text = "Cursor Location";
            this.sbLabelImagePosition.ToolTipText = "Cursor location relative to the image";
            // 
            // sbLabelImageSize
            // 
            this.sbLabelImageSize.Image = global::MineralAnalysis.Properties.Resources.scale16x16;
            this.sbLabelImageSize.Name = "sbLabelImageSize";
            this.sbLabelImageSize.Size = new System.Drawing.Size(79, 17);
            this.sbLabelImageSize.Text = "Image Size";
            this.sbLabelImageSize.ToolTipText = "Image size in pixels";
            // 
            // sbLabelImageScrollPosition
            // 
            this.sbLabelImageScrollPosition.Image = global::MineralAnalysis.Properties.Resources.cursor_move16x16;
            this.sbLabelImageScrollPosition.Name = "sbLabelImageScrollPosition";
            this.sbLabelImageScrollPosition.Size = new System.Drawing.Size(98, 17);
            this.sbLabelImageScrollPosition.Text = "Scroll Position";
            this.sbLabelImageScrollPosition.ToolTipText = "Scroll position relative to the image";
            // 
            // sbLabelImageZoom
            // 
            this.sbLabelImageZoom.Image = global::MineralAnalysis.Properties.Resources.zoom16x16;
            this.sbLabelImageZoom.Name = "sbLabelImageZoom";
            this.sbLabelImageZoom.Size = new System.Drawing.Size(55, 17);
            this.sbLabelImageZoom.Text = "Zoom";
            this.sbLabelImageZoom.ToolTipText = "Zoom";
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1420, 780);
            this.tabControl.TabIndex = 4;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 826);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "FrmMain";
            this.Text = "Mineral Analysis";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuBtnLoadImageCurrentTab;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelReady;
        private System.Windows.Forms.ToolStripProgressBar sbProgress;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelSpring;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelImagePosition;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelImageZoom;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelImageSize;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelImageScrollPosition;
        private System.Windows.Forms.ToolStripMenuItem btnMainMenuExit;
        private System.Windows.Forms.ToolStripSeparator menuBarSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mainMenuBtnImageNewTab;
        private System.Windows.Forms.ToolStripMenuItem mainMenuBtnCloseCurrentTab;
    }
}

