using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using MineralAnalysis.Controls;

namespace MineralAnalysis
{
    public partial class FrmMain : Form
    {
        #region Properties
        private List<CtrlTabPage> TabPages { get; } = new List<CtrlTabPage>();
        private readonly ToolStripItem[] _dynamicStatusBarItems;
        #endregion

        #region Constructor
        public FrmMain()
        {
            InitializeComponent();

            Text = $"{Text} {Application.ProductVersion}";

            _dynamicStatusBarItems = new ToolStripItem[]
            {
                sbLabelImagePosition,
                sbLabelImageSize,
                sbLabelImageScrollPosition,
                sbLabelImageZoom,
            };

            UpdateStatusBar();

            tabControl.SelectedIndexChanged += (sender, args) => UpdateMainMenu();
            tabControl.ControlAdded += (sender, args) => UpdateMainMenu();
            tabControl.ControlRemoved += (sender, args) => UpdateMainMenu();
            
        }
        #endregion

        #region Methods
        public void UpdateStatusBar()
        {
            if (tabControl.SelectedIndex >= 0 && tabControl.TabCount > 0)
            {
                CtrlTabPage TabPage = tabControl.SelectedTab.Tag as CtrlTabPage;
                if (!TabPage.IsLoaded)
                {
                    SetVisibleStatusBarDynamicItems(false);
                    return;
                }

                sbLabelImagePosition.Text = TabPage.ImageCursorLocation.ToString();
                sbLabelImageSize.Text = TabPage.ImageSize.ToString();
                sbLabelImageScrollPosition.Text = TabPage.ImageScrollPosition.ToString();
                sbLabelImageZoom.Text = $"{TabPage.ImageZoom}% ({TabPage.ImageZoomFactor}x)";

                SetVisibleStatusBarDynamicItems(true);
            }
            else
            {
                SetVisibleStatusBarDynamicItems(false);
            }
        }

        public void SetVisibleStatusBarDynamicItems(bool visible)
        {
            foreach (var dynamicItem in _dynamicStatusBarItems)
            {
                dynamicItem.Visible = visible;
            }
        }


        public void CloseTab(TabPage tabPage)
        {
            CtrlTabPage tab = tabControl.SelectedTab.Tag as CtrlTabPage;
            tab.Dispose();
            tabPage.Dispose();
        }

        public void LoadImage(string filename, bool newTab = true)
        {
            CtrlTabPage tab = new CtrlTabPage(filename) {Dock = DockStyle.Fill};
            TabPages.Add(tab);
            
            if (newTab)
            {
                TabPage page = new TabPage(tab.FileNameWithoutExtension) {Tag = tab};
                page.Controls.Add(tab);
                tabControl.TabPages.Add(page);
            }
            else
            {
                TabPage page = tabControl.SelectedTab;
                (page.Tag as CtrlTabPage).Dispose();
                foreach (Control pageControl in page.Controls)
                {
                    pageControl.Dispose();
                }
                page.Controls.Clear();
                page.Tag = tab;
                page.Text = tab.FileNameWithoutExtension;
                page.Controls.Add(tab);
            }
            tab.ProcessImage();
        }
        #endregion

        #region Events
        private void EventClick(object sender, EventArgs e)
        {
            if (ReferenceEquals(sender, mainMenuBtnImageNewTab) || ReferenceEquals(sender, mainMenuBtnLoadImageCurrentTab))
            {
                if (ReferenceEquals(sender, mainMenuBtnLoadImageCurrentTab))
                {
                    if (MessageBox.Show(
                            "The currently open tab will be closed, all work will be lost and loaded with a new image.\nYou have sure you wan't to continue?",
                            "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                }
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.CheckFileExists = true;
                    dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    dialog.RestoreDirectory = true;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadImage(dialog.FileName, sender == mainMenuBtnImageNewTab);
                    }
                }

                return;
            }
            if (ReferenceEquals(sender, mainMenuBtnCloseCurrentTab))
            {
                if (MessageBox.Show(
                        "The currently open tab will be closed and all work will be lost.\nYou have sure you wan't to continue?",
                        "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                
                CloseTab(tabControl.SelectedTab);
            }

            if (ReferenceEquals(sender, btnMainMenuExit))
            {
                Close();
                return;
            }
        }
        #endregion

        private void UpdateMainMenu()
        {
            mainMenuBtnLoadImageCurrentTab.Enabled =
                mainMenuBtnCloseCurrentTab.Enabled =
                tabControl.TabCount > 0 && tabControl.SelectedIndex >= 0;
        }
    }
}
