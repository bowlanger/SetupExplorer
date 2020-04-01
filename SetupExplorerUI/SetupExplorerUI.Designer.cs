namespace SetupExplorerUI
{
    partial class mainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cFLLabel = new System.Windows.Forms.Label();
            this.cFRLabel = new System.Windows.Forms.Label();
            this.cLFLabel = new System.Windows.Forms.Label();
            this.cCFLabel = new System.Windows.Forms.Label();
            this.cRFLabel = new System.Windows.Forms.Label();
            this.cLMLabel = new System.Windows.Forms.Label();
            this.cCMLabel = new System.Windows.Forms.Label();
            this.cRMLabel = new System.Windows.Forms.Label();
            this.cLRLabel = new System.Windows.Forms.Label();
            this.cCRLabel = new System.Windows.Forms.Label();
            this.cRRLabel = new System.Windows.Forms.Label();
            this.cBLLabel = new System.Windows.Forms.Label();
            this.cBMLabel = new System.Windows.Forms.Label();
            this.cBRLabel = new System.Windows.Forms.Label();
            this.cFMLabel = new System.Windows.Forms.Label();
            this.scHeaderTextBox = new System.Windows.Forms.TextBox();
            this.openOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(484, 24);
            this.mainMenuStrip.TabIndex = 0;
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
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
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
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 3;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.mainTableLayoutPanel.Controls.Add(this.scHeaderTextBox, 0, 0);
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
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 7;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(484, 537);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // cFLLabel
            // 
            this.cFLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cFLLabel.AutoSize = true;
            this.cFLLabel.Location = new System.Drawing.Point(46, 100);
            this.cFLLabel.Name = "cFLLabel";
            this.cFLLabel.Size = new System.Drawing.Size(52, 13);
            this.cFLLabel.TabIndex = 0;
            this.cFLLabel.Text = "Front Left";
            // 
            // cFRLabel
            // 
            this.cFRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cFRLabel.AutoSize = true;
            this.cFRLabel.Location = new System.Drawing.Point(381, 100);
            this.cFRLabel.Name = "cFRLabel";
            this.cFRLabel.Size = new System.Drawing.Size(59, 13);
            this.cFRLabel.TabIndex = 2;
            this.cFRLabel.Text = "Front Right";
            // 
            // cLFLabel
            // 
            this.cLFLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cLFLabel.AutoSize = true;
            this.cLFLabel.Location = new System.Drawing.Point(46, 187);
            this.cLFLabel.Name = "cLFLabel";
            this.cLFLabel.Size = new System.Drawing.Size(52, 13);
            this.cLFLabel.TabIndex = 3;
            this.cLFLabel.Text = "Left Front";
            // 
            // cCFLabel
            // 
            this.cCFLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cCFLabel.AutoSize = true;
            this.cCFLabel.Location = new System.Drawing.Point(209, 187);
            this.cCFLabel.Name = "cCFLabel";
            this.cCFLabel.Size = new System.Drawing.Size(65, 13);
            this.cCFLabel.TabIndex = 4;
            this.cCFLabel.Text = "Center Front";
            // 
            // cRFLabel
            // 
            this.cRFLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cRFLabel.AutoSize = true;
            this.cRFLabel.Location = new System.Drawing.Point(381, 187);
            this.cRFLabel.Name = "cRFLabel";
            this.cRFLabel.Size = new System.Drawing.Size(59, 13);
            this.cRFLabel.TabIndex = 5;
            this.cRFLabel.Text = "Right Front";
            // 
            // cLMLabel
            // 
            this.cLMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cLMLabel.AutoSize = true;
            this.cLMLabel.Location = new System.Drawing.Point(43, 274);
            this.cLMLabel.Name = "cLMLabel";
            this.cLMLabel.Size = new System.Drawing.Size(59, 13);
            this.cLMLabel.TabIndex = 6;
            this.cLMLabel.Text = "Left Middle";
            // 
            // cCMLabel
            // 
            this.cCMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cCMLabel.AutoSize = true;
            this.cCMLabel.Location = new System.Drawing.Point(205, 274);
            this.cCMLabel.Name = "cCMLabel";
            this.cCMLabel.Size = new System.Drawing.Size(72, 13);
            this.cCMLabel.TabIndex = 7;
            this.cCMLabel.Text = "Center Middle";
            // 
            // cRMLabel
            // 
            this.cRMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cRMLabel.AutoSize = true;
            this.cRMLabel.Location = new System.Drawing.Point(378, 274);
            this.cRMLabel.Name = "cRMLabel";
            this.cRMLabel.Size = new System.Drawing.Size(66, 13);
            this.cRMLabel.TabIndex = 8;
            this.cRMLabel.Text = "Right Middle";
            // 
            // cLRLabel
            // 
            this.cLRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cLRLabel.AutoSize = true;
            this.cLRLabel.Location = new System.Drawing.Point(47, 361);
            this.cLRLabel.Name = "cLRLabel";
            this.cLRLabel.Size = new System.Drawing.Size(51, 13);
            this.cLRLabel.TabIndex = 9;
            this.cLRLabel.Text = "Left Rear";
            // 
            // cCRLabel
            // 
            this.cCRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cCRLabel.AutoSize = true;
            this.cCRLabel.Location = new System.Drawing.Point(209, 361);
            this.cCRLabel.Name = "cCRLabel";
            this.cCRLabel.Size = new System.Drawing.Size(64, 13);
            this.cCRLabel.TabIndex = 10;
            this.cCRLabel.Text = "Center Rear";
            // 
            // cRRLabel
            // 
            this.cRRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cRRLabel.AutoSize = true;
            this.cRRLabel.Location = new System.Drawing.Point(382, 361);
            this.cRRLabel.Name = "cRRLabel";
            this.cRRLabel.Size = new System.Drawing.Size(58, 13);
            this.cRRLabel.TabIndex = 11;
            this.cRRLabel.Text = "Right Rear";
            // 
            // cBLLabel
            // 
            this.cBLLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBLLabel.AutoSize = true;
            this.cBLLabel.Location = new System.Drawing.Point(46, 448);
            this.cBLLabel.Name = "cBLLabel";
            this.cBLLabel.Size = new System.Drawing.Size(53, 13);
            this.cBLLabel.TabIndex = 12;
            this.cBLLabel.Text = "Back Left";
            // 
            // cBMLabel
            // 
            this.cBMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBMLabel.AutoSize = true;
            this.cBMLabel.Location = new System.Drawing.Point(208, 448);
            this.cBMLabel.Name = "cBMLabel";
            this.cBMLabel.Size = new System.Drawing.Size(66, 13);
            this.cBMLabel.TabIndex = 13;
            this.cBMLabel.Text = "Back Middle";
            // 
            // cBRLabel
            // 
            this.cBRLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cBRLabel.AutoSize = true;
            this.cBRLabel.Location = new System.Drawing.Point(381, 448);
            this.cBRLabel.Name = "cBRLabel";
            this.cBRLabel.Size = new System.Drawing.Size(60, 13);
            this.cBRLabel.TabIndex = 14;
            this.cBRLabel.Text = "Back Right";
            // 
            // cFMLabel
            // 
            this.cFMLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cFMLabel.AutoSize = true;
            this.cFMLabel.Location = new System.Drawing.Point(209, 100);
            this.cFMLabel.Name = "cFMLabel";
            this.cFMLabel.Size = new System.Drawing.Size(65, 13);
            this.cFMLabel.TabIndex = 1;
            this.cFMLabel.Text = "Front Middle";
            // 
            // scHeaderTextBox
            // 
            this.mainTableLayoutPanel.SetColumnSpan(this.scHeaderTextBox, 3);
            this.scHeaderTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.scHeaderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scHeaderTextBox.Location = new System.Drawing.Point(3, 3);
            this.scHeaderTextBox.Multiline = true;
            this.scHeaderTextBox.Name = "scHeaderTextBox";
            this.scHeaderTextBox.ReadOnly = true;
            this.scHeaderTextBox.Size = new System.Drawing.Size(478, 44);
            this.scHeaderTextBox.TabIndex = 15;
            this.scHeaderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openOpenFileDialog
            // 
            this.openOpenFileDialog.Filter = "Exported Setup Files|*.htm|All Files|*.*";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 539);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(484, 22);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainToolStripStatusLabel
            // 
            this.mainToolStripStatusLabel.Name = "mainToolStripStatusLabel";
            this.mainToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "mainForm";
            this.Text = "Setup Explorer";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Label cFLLabel;
        private System.Windows.Forms.Label cFMLabel;
        private System.Windows.Forms.Label cFRLabel;
        private System.Windows.Forms.Label cLFLabel;
        private System.Windows.Forms.Label cCFLabel;
        private System.Windows.Forms.Label cRFLabel;
        private System.Windows.Forms.Label cLMLabel;
        private System.Windows.Forms.Label cCMLabel;
        private System.Windows.Forms.Label cRMLabel;
        private System.Windows.Forms.Label cLRLabel;
        private System.Windows.Forms.Label cCRLabel;
        private System.Windows.Forms.Label cRRLabel;
        private System.Windows.Forms.Label cBLLabel;
        private System.Windows.Forms.Label cBMLabel;
        private System.Windows.Forms.Label cBRLabel;
        private System.Windows.Forms.OpenFileDialog openOpenFileDialog;
        private System.Windows.Forms.TextBox scHeaderTextBox;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel mainToolStripStatusLabel;
    }
}

