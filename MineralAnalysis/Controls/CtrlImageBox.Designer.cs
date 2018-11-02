namespace MineralAnalysis.Controls
{
    partial class CtrlImageBox
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
            this.tsActions = new System.Windows.Forms.ToolStrip();
            this.tsBarBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBarLabelName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsActionLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsActionsTextbox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tsActionLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsActionsTextbox2 = new System.Windows.Forms.ToolStripTextBox();
            this.tsActionLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsActionsTextbox3 = new System.Windows.Forms.ToolStripTextBox();
            this.tsActionsLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsActionsCombobox1 = new System.Windows.Forms.ToolStripComboBox();
            this.tsActionsBtnFilterApply = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsActionsLabelMS = new System.Windows.Forms.ToolStripButton();
            this.tsActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsActions
            // 
            this.tsActions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBarBtnSave,
            this.tsBarLabelName,
            this.toolStripSeparator1,
            this.tsActionLabel1,
            this.tsActionsTextbox1,
            this.tsActionLabel2,
            this.tsActionsTextbox2,
            this.tsActionLabel3,
            this.tsActionsTextbox3,
            this.tsActionsLabel4,
            this.tsActionsCombobox1,
            this.tsActionsBtnFilterApply,
            this.toolStripSeparator2,
            this.tsActionsLabelMS});
            this.tsActions.Location = new System.Drawing.Point(0, 0);
            this.tsActions.Name = "tsActions";
            this.tsActions.Size = new System.Drawing.Size(1000, 25);
            this.tsActions.TabIndex = 0;
            this.tsActions.Text = "Actions Bar";
            // 
            // tsBarBtnSave
            // 
            this.tsBarBtnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsBarBtnSave.Image = global::MineralAnalysis.Properties.Resources.save16x16;
            this.tsBarBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBarBtnSave.Name = "tsBarBtnSave";
            this.tsBarBtnSave.Size = new System.Drawing.Size(60, 22);
            this.tsBarBtnSave.Text = "&Export";
            this.tsBarBtnSave.ToolTipText = "Export and save current image in the local disk";
            this.tsBarBtnSave.Click += new System.EventHandler(this.EventClick);
            // 
            // tsBarLabelName
            // 
            this.tsBarLabelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsBarLabelName.Name = "tsBarLabelName";
            this.tsBarLabelName.Size = new System.Drawing.Size(40, 22);
            this.tsBarLabelName.Text = "Name";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsActionLabel1
            // 
            this.tsActionLabel1.Name = "tsActionLabel1";
            this.tsActionLabel1.Size = new System.Drawing.Size(44, 22);
            this.tsActionLabel1.Text = "Label 1";
            // 
            // tsActionsTextbox1
            // 
            this.tsActionsTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsActionsTextbox1.MaxLength = 4;
            this.tsActionsTextbox1.Name = "tsActionsTextbox1";
            this.tsActionsTextbox1.Size = new System.Drawing.Size(50, 25);
            this.tsActionsTextbox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EventKeyPress);
            this.tsActionsTextbox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EventKeyUp);
            // 
            // tsActionLabel2
            // 
            this.tsActionLabel2.Name = "tsActionLabel2";
            this.tsActionLabel2.Size = new System.Drawing.Size(44, 22);
            this.tsActionLabel2.Text = "Label 2";
            // 
            // tsActionsTextbox2
            // 
            this.tsActionsTextbox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsActionsTextbox2.MaxLength = 4;
            this.tsActionsTextbox2.Name = "tsActionsTextbox2";
            this.tsActionsTextbox2.Size = new System.Drawing.Size(50, 25);
            this.tsActionsTextbox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EventKeyPress);
            this.tsActionsTextbox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EventKeyUp);
            // 
            // tsActionLabel3
            // 
            this.tsActionLabel3.Name = "tsActionLabel3";
            this.tsActionLabel3.Size = new System.Drawing.Size(44, 22);
            this.tsActionLabel3.Text = "Label 3";
            // 
            // tsActionsTextbox3
            // 
            this.tsActionsTextbox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsActionsTextbox3.MaxLength = 4;
            this.tsActionsTextbox3.Name = "tsActionsTextbox3";
            this.tsActionsTextbox3.Size = new System.Drawing.Size(50, 25);
            this.tsActionsTextbox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EventKeyPress);
            this.tsActionsTextbox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EventKeyUp);
            // 
            // tsActionsLabel4
            // 
            this.tsActionsLabel4.Name = "tsActionsLabel4";
            this.tsActionsLabel4.Size = new System.Drawing.Size(44, 22);
            this.tsActionsLabel4.Text = "Label 4";
            // 
            // tsActionsCombobox1
            // 
            this.tsActionsCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsActionsCombobox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tsActionsCombobox1.MaxLength = 4;
            this.tsActionsCombobox1.Name = "tsActionsCombobox1";
            this.tsActionsCombobox1.Size = new System.Drawing.Size(75, 25);
            this.tsActionsCombobox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EventKeyUp);
            // 
            // tsActionsBtnFilterApply
            // 
            this.tsActionsBtnFilterApply.Image = global::MineralAnalysis.Properties.Resources.sql_join_right_exclude16x16;
            this.tsActionsBtnFilterApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsActionsBtnFilterApply.Name = "tsActionsBtnFilterApply";
            this.tsActionsBtnFilterApply.Size = new System.Drawing.Size(58, 22);
            this.tsActionsBtnFilterApply.Text = "Apply";
            this.tsActionsBtnFilterApply.Click += new System.EventHandler(this.EventClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsActionsLabelMS
            // 
            this.tsActionsLabelMS.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsActionsLabelMS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsActionsLabelMS.Name = "tsActionsLabelMS";
            this.tsActionsLabelMS.Size = new System.Drawing.Size(27, 22);
            this.tsActionsLabelMS.Text = "ms";
            this.tsActionsLabelMS.ToolTipText = "Processing time";
            // 
            // CtrlImageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsActions);
            this.Name = "CtrlImageBox";
            this.Size = new System.Drawing.Size(1000, 784);
            this.tsActions.ResumeLayout(false);
            this.tsActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsActions;
        private System.Windows.Forms.ToolStripButton tsBarBtnSave;
        private System.Windows.Forms.ToolStripLabel tsBarLabelName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tsActionLabel1;
        private System.Windows.Forms.ToolStripLabel tsActionLabel2;
        private System.Windows.Forms.ToolStripLabel tsActionLabel3;
        private System.Windows.Forms.ToolStripTextBox tsActionsTextbox1;
        private System.Windows.Forms.ToolStripTextBox tsActionsTextbox2;
        private System.Windows.Forms.ToolStripTextBox tsActionsTextbox3;
        private System.Windows.Forms.ToolStripButton tsActionsBtnFilterApply;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tsActionsLabel4;
        private System.Windows.Forms.ToolStripComboBox tsActionsCombobox1;
        private System.Windows.Forms.ToolStripButton tsActionsLabelMS;
    }
}
