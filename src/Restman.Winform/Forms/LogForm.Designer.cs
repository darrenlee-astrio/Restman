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
            allLogsTextBox = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            tabControl1 = new TabControl();
            allLogsTab = new TabPage();
            errorLogsTab = new TabPage();
            informationLogTab = new TabPage();
            tabControl1.SuspendLayout();
            allLogsTab.SuspendLayout();
            SuspendLayout();
            // 
            // allLogsTextBox
            // 
            allLogsTextBox.Dock = DockStyle.Fill;
            allLogsTextBox.Location = new Point(3, 3);
            allLogsTextBox.Name = "allLogsTextBox";
            allLogsTextBox.Size = new Size(725, 343);
            allLogsTextBox.TabIndex = 0;
            allLogsTextBox.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(676, 391);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(595, 391);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(16, 395);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(100, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Scroll to Caret";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(allLogsTab);
            tabControl1.Controls.Add(errorLogsTab);
            tabControl1.Controls.Add(informationLogTab);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(739, 377);
            tabControl1.TabIndex = 4;
            // 
            // allLogsTab
            // 
            allLogsTab.Controls.Add(allLogsTextBox);
            allLogsTab.Location = new Point(4, 24);
            allLogsTab.Name = "allLogsTab";
            allLogsTab.Padding = new Padding(3);
            allLogsTab.Size = new Size(731, 349);
            allLogsTab.TabIndex = 0;
            allLogsTab.Text = "All";
            allLogsTab.UseVisualStyleBackColor = true;
            // 
            // errorLogsTab
            // 
            errorLogsTab.Location = new Point(4, 24);
            errorLogsTab.Name = "errorLogsTab";
            errorLogsTab.Padding = new Padding(3);
            errorLogsTab.Size = new Size(731, 349);
            errorLogsTab.TabIndex = 1;
            errorLogsTab.Text = "Error";
            errorLogsTab.UseVisualStyleBackColor = true;
            // 
            // informationLogTab
            // 
            informationLogTab.Location = new Point(4, 24);
            informationLogTab.Name = "informationLogTab";
            informationLogTab.Size = new Size(731, 349);
            informationLogTab.TabIndex = 2;
            informationLogTab.Text = "Info";
            informationLogTab.UseVisualStyleBackColor = true;
            // 
            // LogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 423);
            Controls.Add(tabControl1);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "LogForm";
            Text = "Logs";
            tabControl1.ResumeLayout(false);
            allLogsTab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox allLogsTextBox;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private TabControl tabControl1;
        private TabPage allLogsTab;
        private TabPage errorLogsTab;
        private TabPage informationLogTab;
    }
}