namespace MineralAnalysis.Controls
{
    partial class CtrlTabPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Properties", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("AI Results", System.Windows.Forms.HorizontalAlignment.Left);
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tlImages = new System.Windows.Forms.TableLayoutPanel();
            this.scDataHistogram = new System.Windows.Forms.SplitContainer();
            this.lvData = new System.Windows.Forms.ListView();
            this.lvDataColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvDataColData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scDataHistogram)).BeginInit();
            this.scDataHistogram.Panel1.SuspendLayout();
            this.scDataHistogram.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tlImages);
            this.scMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scDataHistogram);
            this.scMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scMain.Panel2MinSize = 350;
            this.scMain.Size = new System.Drawing.Size(1625, 897);
            this.scMain.SplitterDistance = 1271;
            this.scMain.TabIndex = 3;
            // 
            // tlImages
            // 
            this.tlImages.ColumnCount = 2;
            this.tlImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlImages.Location = new System.Drawing.Point(0, 0);
            this.tlImages.Name = "tlImages";
            this.tlImages.RowCount = 3;
            this.tlImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlImages.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlImages.Size = new System.Drawing.Size(1271, 897);
            this.tlImages.TabIndex = 1;
            // 
            // scDataHistogram
            // 
            this.scDataHistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDataHistogram.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scDataHistogram.Location = new System.Drawing.Point(0, 0);
            this.scDataHistogram.Name = "scDataHistogram";
            this.scDataHistogram.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scDataHistogram.Panel1
            // 
            this.scDataHistogram.Panel1.Controls.Add(this.lvData);
            this.scDataHistogram.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // scDataHistogram.Panel2
            // 
            this.scDataHistogram.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scDataHistogram.Size = new System.Drawing.Size(350, 897);
            this.scDataHistogram.SplitterDistance = 288;
            this.scDataHistogram.TabIndex = 1;
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvDataColName,
            this.lvDataColData});
            this.lvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvData.FullRowSelect = true;
            listViewGroup1.Header = "Properties";
            listViewGroup1.Name = "lvDataGroupProperties";
            listViewGroup2.Header = "AI Results";
            listViewGroup2.Name = "lvDataGroupAIResults";
            this.lvData.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvData.Location = new System.Drawing.Point(0, 0);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(350, 288);
            this.lvData.TabIndex = 0;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // lvDataColName
            // 
            this.lvDataColName.Text = "Name";
            this.lvDataColName.Width = 150;
            // 
            // lvDataColData
            // 
            this.lvDataColData.Text = "Data";
            this.lvDataColData.Width = 150;
            // 
            // CtrlTabPage
            // 
            this.Controls.Add(this.scMain);
            this.Name = "CtrlTabPage";
            this.Size = new System.Drawing.Size(1625, 897);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scDataHistogram.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scDataHistogram)).EndInit();
            this.scDataHistogram.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TableLayoutPanel tlImages;
        private System.Windows.Forms.ColumnHeader lvDataColName;
        private System.Windows.Forms.ColumnHeader lvDataColData;
        private System.Windows.Forms.SplitContainer scDataHistogram;
        public System.Windows.Forms.ListView lvData;
    }
}
