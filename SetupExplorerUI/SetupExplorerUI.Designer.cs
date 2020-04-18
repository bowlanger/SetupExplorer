namespace SetupExplorerUI
{
    partial class SetupExplorerForm
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
            this.seMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.seStatusStrip = new System.Windows.Forms.StatusStrip();
            this.seToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbConsole = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cBLLabel = new System.Windows.Forms.Label();
            this.cBMLabel = new System.Windows.Forms.Label();
            this.cBRLabel = new System.Windows.Forms.Label();
            this.cLRLabel = new System.Windows.Forms.Label();
            this.cCRLabel = new System.Windows.Forms.Label();
            this.cRRLabel = new System.Windows.Forms.Label();
            this.cRMLabel = new System.Windows.Forms.Label();
            this.cCMLabel = new System.Windows.Forms.Label();
            this.cLMLabel = new System.Windows.Forms.Label();
            this.cLFLabel = new System.Windows.Forms.Label();
            this.cCFLabel = new System.Windows.Forms.Label();
            this.cRFLabel = new System.Windows.Forms.Label();
            this.cFRLabel = new System.Windows.Forms.Label();
            this.cFMLabel = new System.Windows.Forms.Label();
            this.cFLLabel = new System.Windows.Forms.Label();
            this.seHeaderReadOnlyTextBox = new SetupExplorerUI.Components.ReadOnlyTextBox();
            this.seMenuStrip.SuspendLayout();
            this.seStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // seMenuStrip
            // 
            this.seMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.seMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.seMenuStrip.Name = "seMenuStrip";
            this.seMenuStrip.Size = new System.Drawing.Size(785, 24);
            this.seMenuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.VersionToolStripMenuItem_Click);
            // 
            // seOpenFileDialog
            // 
            this.seOpenFileDialog.Filter = "Exported Setup Files|*.htm|All Files|*.*";
            // 
            // seStatusStrip
            // 
            this.seStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seToolStripStatusLabel});
            this.seStatusStrip.Location = new System.Drawing.Point(0, 617);
            this.seStatusStrip.Name = "seStatusStrip";
            this.seStatusStrip.Size = new System.Drawing.Size(785, 22);
            this.seStatusStrip.TabIndex = 2;
            this.seStatusStrip.Text = "statusStrip1";
            // 
            // seToolStripStatusLabel
            // 
            this.seToolStripStatusLabel.Name = "seToolStripStatusLabel";
            this.seToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tbConsole
            // 
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsole.Location = new System.Drawing.Point(0, 0);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(385, 593);
            this.tbConsole.TabIndex = 3;
            this.tbConsole.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainTableLayoutPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbConsole);
            this.splitContainer1.Size = new System.Drawing.Size(785, 593);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 4;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 3;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainTableLayoutPanel.Controls.Add(this.cBLLabel, 0, 6);
            this.mainTableLayoutPanel.Controls.Add(this.cBMLabel, 1, 6);
            this.mainTableLayoutPanel.Controls.Add(this.cBRLabel, 2, 6);
            this.mainTableLayoutPanel.Controls.Add(this.cLRLabel, 0, 5);
            this.mainTableLayoutPanel.Controls.Add(this.cCRLabel, 1, 5);
            this.mainTableLayoutPanel.Controls.Add(this.cRRLabel, 2, 5);
            this.mainTableLayoutPanel.Controls.Add(this.cRMLabel, 2, 4);
            this.mainTableLayoutPanel.Controls.Add(this.cCMLabel, 1, 4);
            this.mainTableLayoutPanel.Controls.Add(this.cLMLabel, 0, 4);
            this.mainTableLayoutPanel.Controls.Add(this.cLFLabel, 0, 3);
            this.mainTableLayoutPanel.Controls.Add(this.cCFLabel, 1, 3);
            this.mainTableLayoutPanel.Controls.Add(this.cRFLabel, 2, 3);
            this.mainTableLayoutPanel.Controls.Add(this.cFRLabel, 2, 2);
            this.mainTableLayoutPanel.Controls.Add(this.cFMLabel, 1, 2);
            this.mainTableLayoutPanel.Controls.Add(this.cFLLabel, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.seHeaderReadOnlyTextBox, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 7;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(396, 593);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // cBLLabel
            // 
            this.cBLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBLLabel.AutoSize = true;
            this.cBLLabel.Location = new System.Drawing.Point(33, 492);
            this.cBLLabel.Name = "cBLLabel";
            this.cBLLabel.Size = new System.Drawing.Size(51, 13);
            this.cBLLabel.TabIndex = 12;
            this.cBLLabel.Text = "Rear Left";
            // 
            // cBMLabel
            // 
            this.cBMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBMLabel.AutoSize = true;
            this.cBMLabel.Location = new System.Drawing.Point(182, 492);
            this.cBMLabel.Name = "cBMLabel";
            this.cBMLabel.Size = new System.Drawing.Size(30, 13);
            this.cBMLabel.TabIndex = 13;
            this.cBMLabel.Text = "Rear";
            // 
            // cBRLabel
            // 
            this.cBRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBRLabel.AutoSize = true;
            this.cBRLabel.Location = new System.Drawing.Point(307, 492);
            this.cBRLabel.Name = "cBRLabel";
            this.cBRLabel.Size = new System.Drawing.Size(58, 13);
            this.cBRLabel.TabIndex = 14;
            this.cBRLabel.Text = "Rear Right";
            // 
            // cLRLabel
            // 
            this.cLRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cLRLabel.AutoSize = true;
            this.cLRLabel.Location = new System.Drawing.Point(33, 394);
            this.cLRLabel.Name = "cLRLabel";
            this.cLRLabel.Size = new System.Drawing.Size(51, 13);
            this.cLRLabel.TabIndex = 9;
            this.cLRLabel.Text = "Left Rear";
            // 
            // cCRLabel
            // 
            this.cCRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cCRLabel.AutoSize = true;
            this.cCRLabel.Location = new System.Drawing.Point(165, 394);
            this.cCRLabel.Name = "cCRLabel";
            this.cCRLabel.Size = new System.Drawing.Size(64, 13);
            this.cCRLabel.TabIndex = 10;
            this.cCRLabel.Text = "Center Rear";
            // 
            // cRRLabel
            // 
            this.cRRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cRRLabel.AutoSize = true;
            this.cRRLabel.Location = new System.Drawing.Point(307, 394);
            this.cRRLabel.Name = "cRRLabel";
            this.cRRLabel.Size = new System.Drawing.Size(58, 13);
            this.cRRLabel.TabIndex = 11;
            this.cRRLabel.Text = "Right Rear";
            // 
            // cRMLabel
            // 
            this.cRMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cRMLabel.AutoSize = true;
            this.cRMLabel.Location = new System.Drawing.Point(320, 296);
            this.cRMLabel.Name = "cRMLabel";
            this.cRMLabel.Size = new System.Drawing.Size(32, 13);
            this.cRMLabel.TabIndex = 8;
            this.cRMLabel.Text = "Right";
            // 
            // cCMLabel
            // 
            this.cCMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cCMLabel.AutoSize = true;
            this.cCMLabel.Location = new System.Drawing.Point(178, 296);
            this.cCMLabel.Name = "cCMLabel";
            this.cCMLabel.Size = new System.Drawing.Size(38, 13);
            this.cCMLabel.TabIndex = 7;
            this.cCMLabel.Text = "Center";
            // 
            // cLMLabel
            // 
            this.cLMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cLMLabel.AutoSize = true;
            this.cLMLabel.Location = new System.Drawing.Point(46, 296);
            this.cLMLabel.Name = "cLMLabel";
            this.cLMLabel.Size = new System.Drawing.Size(25, 13);
            this.cLMLabel.TabIndex = 6;
            this.cLMLabel.Text = "Left";
            // 
            // cLFLabel
            // 
            this.cLFLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cLFLabel.AutoSize = true;
            this.cLFLabel.Location = new System.Drawing.Point(33, 198);
            this.cLFLabel.Name = "cLFLabel";
            this.cLFLabel.Size = new System.Drawing.Size(52, 13);
            this.cLFLabel.TabIndex = 3;
            this.cLFLabel.Text = "Left Front";
            // 
            // cCFLabel
            // 
            this.cCFLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cCFLabel.AutoSize = true;
            this.cCFLabel.Location = new System.Drawing.Point(164, 198);
            this.cCFLabel.Name = "cCFLabel";
            this.cCFLabel.Size = new System.Drawing.Size(65, 13);
            this.cCFLabel.TabIndex = 4;
            this.cCFLabel.Text = "Center Front";
            // 
            // cRFLabel
            // 
            this.cRFLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cRFLabel.AutoSize = true;
            this.cRFLabel.Location = new System.Drawing.Point(306, 198);
            this.cRFLabel.Name = "cRFLabel";
            this.cRFLabel.Size = new System.Drawing.Size(59, 13);
            this.cRFLabel.TabIndex = 5;
            this.cRFLabel.Text = "Right Front";
            // 
            // cFRLabel
            // 
            this.cFRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cFRLabel.AutoSize = true;
            this.cFRLabel.Location = new System.Drawing.Point(306, 100);
            this.cFRLabel.Name = "cFRLabel";
            this.cFRLabel.Size = new System.Drawing.Size(59, 13);
            this.cFRLabel.TabIndex = 2;
            this.cFRLabel.Text = "Front Right";
            // 
            // cFMLabel
            // 
            this.cFMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cFMLabel.AutoSize = true;
            this.cFMLabel.Location = new System.Drawing.Point(181, 100);
            this.cFMLabel.Name = "cFMLabel";
            this.cFMLabel.Size = new System.Drawing.Size(31, 13);
            this.cFMLabel.TabIndex = 1;
            this.cFMLabel.Text = "Front";
            // 
            // cFLLabel
            // 
            this.cFLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cFLLabel.AutoSize = true;
            this.cFLLabel.Location = new System.Drawing.Point(33, 100);
            this.cFLLabel.Name = "cFLLabel";
            this.cFLLabel.Size = new System.Drawing.Size(52, 13);
            this.cFLLabel.TabIndex = 0;
            this.cFLLabel.Text = "Front Left";
            // 
            // seHeaderReadOnlyTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.seHeaderReadOnlyTextBox, 3);
            this.seHeaderReadOnlyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seHeaderReadOnlyTextBox.Location = new System.Drawing.Point(3, 3);
            this.seHeaderReadOnlyTextBox.Multiline = true;
            this.seHeaderReadOnlyTextBox.Name = "seHeaderReadOnlyTextBox";
            this.seHeaderReadOnlyTextBox.ReadOnly = true;
            this.seHeaderReadOnlyTextBox.Size = new System.Drawing.Size(390, 44);
            this.seHeaderReadOnlyTextBox.TabIndex = 15;
            this.seHeaderReadOnlyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SetupExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 639);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.seStatusStrip);
            this.Controls.Add(this.seMenuStrip);
            this.MainMenuStrip = this.seMenuStrip;
            this.Name = "SetupExplorerForm";
            this.Text = "Setup Explorer 0.1";
            this.seMenuStrip.ResumeLayout(false);
            this.seMenuStrip.PerformLayout();
            this.seStatusStrip.ResumeLayout(false);
            this.seStatusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip seMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog seOpenFileDialog;
        private System.Windows.Forms.StatusStrip seStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel seToolStripStatusLabel;
		private System.Windows.Forms.RichTextBox tbConsole;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Label cBLLabel;
        private System.Windows.Forms.Label cBMLabel;
        private System.Windows.Forms.Label cBRLabel;
        private System.Windows.Forms.Label cLRLabel;
        private System.Windows.Forms.Label cCRLabel;
        private System.Windows.Forms.Label cRRLabel;
        private System.Windows.Forms.Label cRMLabel;
        private System.Windows.Forms.Label cCMLabel;
        private System.Windows.Forms.Label cLMLabel;
        private System.Windows.Forms.Label cLFLabel;
        private System.Windows.Forms.Label cCFLabel;
        private System.Windows.Forms.Label cRFLabel;
        private System.Windows.Forms.Label cFRLabel;
        private System.Windows.Forms.Label cFMLabel;
        private System.Windows.Forms.Label cFLLabel;
        private Components.ReadOnlyTextBox seHeaderReadOnlyTextBox;
    }
}

