namespace Restman.Winform
{
    partial class LogForm
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
            logsTextBox = new RichTextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            scrollToCaretToolStripMenuItem = new ToolStripMenuItem();
            clearOutputToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // logsTextBox
            // 
            logsTextBox.Dock = DockStyle.Fill;
            logsTextBox.Location = new Point(0, 24);
            logsTextBox.Name = "logsTextBox";
            logsTextBox.Size = new Size(993, 399);
            logsTextBox.TabIndex = 0;
            logsTextBox.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(993, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(98, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scrollToCaretToolStripMenuItem, clearOutputToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // scrollToCaretToolStripMenuItem
            // 
            scrollToCaretToolStripMenuItem.Checked = true;
            scrollToCaretToolStripMenuItem.CheckOnClick = true;
            scrollToCaretToolStripMenuItem.CheckState = CheckState.Checked;
            scrollToCaretToolStripMenuItem.Name = "scrollToCaretToolStripMenuItem";
            scrollToCaretToolStripMenuItem.Size = new Size(148, 22);
            scrollToCaretToolStripMenuItem.Text = "Scroll to Caret";
            // 
            // clearOutputToolStripMenuItem
            // 
            clearOutputToolStripMenuItem.Name = "clearOutputToolStripMenuItem";
            clearOutputToolStripMenuItem.Size = new Size(148, 22);
            clearOutputToolStripMenuItem.Text = "Clear Output";
            clearOutputToolStripMenuItem.Click += clearOutputToolStripMenuItem_Click;
            // 
            // LogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 423);
            ControlBox = false;
            Controls.Add(logsTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "LogForm";
            Text = "Logs";
            FormClosing += LogForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox logsTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem scrollToCaretToolStripMenuItem;
        private ToolStripMenuItem clearOutputToolStripMenuItem;
    }
}