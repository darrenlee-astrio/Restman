namespace Restman.Winform.Views;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        groupBox1 = new GroupBox();
        tabControl1 = new TabControl();
        requestHeadersTab = new TabPage();
        headerConfigurationDataGridView = new DataGridView();
        requestBodyTab = new TabPage();
        formDataRequestBodyRadioButton = new RadioButton();
        jsonRequestBodyRadioButton = new RadioButton();
        noRequestBodyRadioButton = new RadioButton();
        bodyConfigurationTabControl = new TabControl();
        noBodyTab = new TabPage();
        label1 = new Label();
        jsonConfigurationTabPage = new TabPage();
        jsonConfigurationTextBox = new RichTextBox();
        formDataConfigurationTab = new TabPage();
        formDataConfigurationDataGridView = new DataGridView();
        requestBodyFormDataDataGridViewEnableColumn = new DataGridViewCheckBoxColumn();
        requestBodyFormDataDataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
        requestBodyFormDataDataGridViewKeyColumn = new DataGridViewTextBoxColumn();
        requestBodyFormDataDataGridViewValueColumn = new DataGridViewTextBoxColumn();
        requestParamsTab = new TabPage();
        queryParameterConfigurationsDataGridView = new DataGridView();
        requestQueryParamsDataGridViewEnableColumn = new DataGridViewCheckBoxColumn();
        requestQueryParamsDataGridViewKeyColumn = new DataGridViewTextBoxColumn();
        requestQueryParamsDataGridViewValueColumn = new DataGridViewTextBoxColumn();
        sendRequestButton = new Button();
        urlTextBox = new TextBox();
        methodsComboBox = new ComboBox();
        groupBox2 = new GroupBox();
        tabControl2 = new TabControl();
        jsonResponseTab = new TabPage();
        jsonResponseTextBox = new RichTextBox();
        responseHeadersTab = new TabPage();
        responseHeadersDataGridView = new DataGridView();
        responseHeadersDataGridViewKeyColumn = new DataGridViewTextBoxColumn();
        responseHeadersDataGridViewValueColumn = new DataGridViewTextBoxColumn();
        responseResultLabel = new Label();
        groupBox3 = new GroupBox();
        requestDescriptionLabel = new Label();
        collectionDescriptionLabel = new Label();
        collectionComboBox = new ComboBox();
        requestComboBox = new ComboBox();
        label3 = new Label();
        label2 = new Label();
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        exitToolStripMenuItem = new ToolStripMenuItem();
        headerConfigurationsDataGridViewEnableColumn = new DataGridViewCheckBoxColumn();
        headerConfigurationsDataGridViewKeyColumn = new DataGridViewTextBoxColumn();
        headerConfigurationsDataGridViewValueColumn = new DataGridViewTextBoxColumn();
        groupBox1.SuspendLayout();
        tabControl1.SuspendLayout();
        requestHeadersTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)headerConfigurationDataGridView).BeginInit();
        requestBodyTab.SuspendLayout();
        bodyConfigurationTabControl.SuspendLayout();
        noBodyTab.SuspendLayout();
        jsonConfigurationTabPage.SuspendLayout();
        formDataConfigurationTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)formDataConfigurationDataGridView).BeginInit();
        requestParamsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)queryParameterConfigurationsDataGridView).BeginInit();
        groupBox2.SuspendLayout();
        tabControl2.SuspendLayout();
        jsonResponseTab.SuspendLayout();
        responseHeadersTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)responseHeadersDataGridView).BeginInit();
        groupBox3.SuspendLayout();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(tabControl1);
        groupBox1.Controls.Add(sendRequestButton);
        groupBox1.Controls.Add(urlTextBox);
        groupBox1.Controls.Add(methodsComboBox);
        groupBox1.Location = new Point(10, 113);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(776, 335);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Request";
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(requestHeadersTab);
        tabControl1.Controls.Add(requestBodyTab);
        tabControl1.Controls.Add(requestParamsTab);
        tabControl1.Location = new Point(6, 51);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(764, 278);
        tabControl1.TabIndex = 3;
        // 
        // requestHeadersTab
        // 
        requestHeadersTab.Controls.Add(headerConfigurationDataGridView);
        requestHeadersTab.Location = new Point(4, 24);
        requestHeadersTab.Name = "requestHeadersTab";
        requestHeadersTab.Padding = new Padding(3);
        requestHeadersTab.Size = new Size(756, 250);
        requestHeadersTab.TabIndex = 1;
        requestHeadersTab.Text = "Headers";
        requestHeadersTab.UseVisualStyleBackColor = true;
        // 
        // headerConfigurationDataGridView
        // 
        headerConfigurationDataGridView.AllowUserToAddRows = false;
        headerConfigurationDataGridView.AllowUserToDeleteRows = false;
        headerConfigurationDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        headerConfigurationDataGridView.Columns.AddRange(new DataGridViewColumn[] { headerConfigurationsDataGridViewEnableColumn, headerConfigurationsDataGridViewKeyColumn, headerConfigurationsDataGridViewValueColumn });
        headerConfigurationDataGridView.Dock = DockStyle.Fill;
        headerConfigurationDataGridView.Location = new Point(3, 3);
        headerConfigurationDataGridView.Name = "headerConfigurationDataGridView";
        headerConfigurationDataGridView.Size = new Size(750, 244);
        headerConfigurationDataGridView.TabIndex = 1;
        // 
        // requestBodyTab
        // 
        requestBodyTab.Controls.Add(formDataRequestBodyRadioButton);
        requestBodyTab.Controls.Add(jsonRequestBodyRadioButton);
        requestBodyTab.Controls.Add(noRequestBodyRadioButton);
        requestBodyTab.Controls.Add(bodyConfigurationTabControl);
        requestBodyTab.Location = new Point(4, 24);
        requestBodyTab.Name = "requestBodyTab";
        requestBodyTab.Size = new Size(756, 250);
        requestBodyTab.TabIndex = 2;
        requestBodyTab.Text = "Body";
        requestBodyTab.UseVisualStyleBackColor = true;
        // 
        // formDataRequestBodyRadioButton
        // 
        formDataRequestBodyRadioButton.AutoSize = true;
        formDataRequestBodyRadioButton.Checked = true;
        formDataRequestBodyRadioButton.Location = new Point(150, 11);
        formDataRequestBodyRadioButton.Name = "formDataRequestBodyRadioButton";
        formDataRequestBodyRadioButton.Size = new Size(82, 19);
        formDataRequestBodyRadioButton.TabIndex = 3;
        formDataRequestBodyRadioButton.TabStop = true;
        formDataRequestBodyRadioButton.Text = "Form-Data";
        formDataRequestBodyRadioButton.UseVisualStyleBackColor = true;
        // 
        // jsonRequestBodyRadioButton
        // 
        jsonRequestBodyRadioButton.AutoSize = true;
        jsonRequestBodyRadioButton.Checked = true;
        jsonRequestBodyRadioButton.Location = new Point(78, 11);
        jsonRequestBodyRadioButton.Name = "jsonRequestBodyRadioButton";
        jsonRequestBodyRadioButton.Size = new Size(53, 19);
        jsonRequestBodyRadioButton.TabIndex = 2;
        jsonRequestBodyRadioButton.TabStop = true;
        jsonRequestBodyRadioButton.Text = "JSON";
        jsonRequestBodyRadioButton.UseVisualStyleBackColor = true;
        // 
        // noRequestBodyRadioButton
        // 
        noRequestBodyRadioButton.AutoSize = true;
        noRequestBodyRadioButton.Checked = true;
        noRequestBodyRadioButton.Location = new Point(7, 11);
        noRequestBodyRadioButton.Name = "noRequestBodyRadioButton";
        noRequestBodyRadioButton.Size = new Size(54, 19);
        noRequestBodyRadioButton.TabIndex = 1;
        noRequestBodyRadioButton.TabStop = true;
        noRequestBodyRadioButton.Text = "None";
        noRequestBodyRadioButton.UseVisualStyleBackColor = true;
        // 
        // bodyConfigurationTabControl
        // 
        bodyConfigurationTabControl.Controls.Add(noBodyTab);
        bodyConfigurationTabControl.Controls.Add(jsonConfigurationTabPage);
        bodyConfigurationTabControl.Controls.Add(formDataConfigurationTab);
        bodyConfigurationTabControl.ItemSize = new Size(1, 15);
        bodyConfigurationTabControl.Location = new Point(0, 36);
        bodyConfigurationTabControl.Name = "bodyConfigurationTabControl";
        bodyConfigurationTabControl.SelectedIndex = 0;
        bodyConfigurationTabControl.Size = new Size(756, 214);
        bodyConfigurationTabControl.TabIndex = 0;
        // 
        // noBodyTab
        // 
        noBodyTab.BackColor = Color.LightGray;
        noBodyTab.Controls.Add(label1);
        noBodyTab.Location = new Point(4, 19);
        noBodyTab.Name = "noBodyTab";
        noBodyTab.Padding = new Padding(3);
        noBodyTab.Size = new Size(748, 191);
        noBodyTab.TabIndex = 0;
        noBodyTab.Text = "None";
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Location = new Point(277, 91);
        label1.Name = "label1";
        label1.Size = new Size(189, 15);
        label1.TabIndex = 0;
        label1.Text = "This request does not have a body.";
        // 
        // jsonConfigurationTabPage
        // 
        jsonConfigurationTabPage.Controls.Add(jsonConfigurationTextBox);
        jsonConfigurationTabPage.Location = new Point(4, 19);
        jsonConfigurationTabPage.Name = "jsonConfigurationTabPage";
        jsonConfigurationTabPage.Padding = new Padding(3);
        jsonConfigurationTabPage.Size = new Size(748, 191);
        jsonConfigurationTabPage.TabIndex = 1;
        jsonConfigurationTabPage.Text = "Json";
        jsonConfigurationTabPage.UseVisualStyleBackColor = true;
        // 
        // jsonConfigurationTextBox
        // 
        jsonConfigurationTextBox.Dock = DockStyle.Fill;
        jsonConfigurationTextBox.Location = new Point(3, 3);
        jsonConfigurationTextBox.Name = "jsonConfigurationTextBox";
        jsonConfigurationTextBox.Size = new Size(742, 185);
        jsonConfigurationTextBox.TabIndex = 0;
        jsonConfigurationTextBox.Text = "";
        // 
        // formDataConfigurationTab
        // 
        formDataConfigurationTab.Controls.Add(formDataConfigurationDataGridView);
        formDataConfigurationTab.Location = new Point(4, 19);
        formDataConfigurationTab.Name = "formDataConfigurationTab";
        formDataConfigurationTab.Size = new Size(748, 191);
        formDataConfigurationTab.TabIndex = 2;
        formDataConfigurationTab.Text = "Form-Data";
        formDataConfigurationTab.UseVisualStyleBackColor = true;
        // 
        // formDataConfigurationDataGridView
        // 
        formDataConfigurationDataGridView.AllowUserToAddRows = false;
        formDataConfigurationDataGridView.AllowUserToDeleteRows = false;
        formDataConfigurationDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        formDataConfigurationDataGridView.Columns.AddRange(new DataGridViewColumn[] { requestBodyFormDataDataGridViewEnableColumn, requestBodyFormDataDataGridViewComboBoxColumn, requestBodyFormDataDataGridViewKeyColumn, requestBodyFormDataDataGridViewValueColumn });
        formDataConfigurationDataGridView.Dock = DockStyle.Fill;
        formDataConfigurationDataGridView.Location = new Point(0, 0);
        formDataConfigurationDataGridView.Name = "formDataConfigurationDataGridView";
        formDataConfigurationDataGridView.Size = new Size(748, 191);
        formDataConfigurationDataGridView.TabIndex = 2;
        // 
        // requestBodyFormDataDataGridViewEnableColumn
        // 
        requestBodyFormDataDataGridViewEnableColumn.HeaderText = "Enable";
        requestBodyFormDataDataGridViewEnableColumn.Name = "requestBodyFormDataDataGridViewEnableColumn";
        // 
        // requestBodyFormDataDataGridViewComboBoxColumn
        // 
        requestBodyFormDataDataGridViewComboBoxColumn.HeaderText = "Type";
        requestBodyFormDataDataGridViewComboBoxColumn.Items.AddRange(new object[] { "Text", "File" });
        requestBodyFormDataDataGridViewComboBoxColumn.Name = "requestBodyFormDataDataGridViewComboBoxColumn";
        // 
        // requestBodyFormDataDataGridViewKeyColumn
        // 
        requestBodyFormDataDataGridViewKeyColumn.HeaderText = "Key";
        requestBodyFormDataDataGridViewKeyColumn.Name = "requestBodyFormDataDataGridViewKeyColumn";
        // 
        // requestBodyFormDataDataGridViewValueColumn
        // 
        requestBodyFormDataDataGridViewValueColumn.HeaderText = "Value";
        requestBodyFormDataDataGridViewValueColumn.Name = "requestBodyFormDataDataGridViewValueColumn";
        // 
        // requestParamsTab
        // 
        requestParamsTab.Controls.Add(queryParameterConfigurationsDataGridView);
        requestParamsTab.Location = new Point(4, 24);
        requestParamsTab.Name = "requestParamsTab";
        requestParamsTab.Padding = new Padding(3);
        requestParamsTab.Size = new Size(756, 250);
        requestParamsTab.TabIndex = 0;
        requestParamsTab.Text = "Params";
        requestParamsTab.UseVisualStyleBackColor = true;
        // 
        // queryParameterConfigurationsDataGridView
        // 
        queryParameterConfigurationsDataGridView.AllowUserToDeleteRows = false;
        queryParameterConfigurationsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        queryParameterConfigurationsDataGridView.Columns.AddRange(new DataGridViewColumn[] { requestQueryParamsDataGridViewEnableColumn, requestQueryParamsDataGridViewKeyColumn, requestQueryParamsDataGridViewValueColumn });
        queryParameterConfigurationsDataGridView.Dock = DockStyle.Fill;
        queryParameterConfigurationsDataGridView.Location = new Point(3, 3);
        queryParameterConfigurationsDataGridView.Name = "queryParameterConfigurationsDataGridView";
        queryParameterConfigurationsDataGridView.Size = new Size(750, 244);
        queryParameterConfigurationsDataGridView.TabIndex = 0;
        // 
        // requestQueryParamsDataGridViewEnableColumn
        // 
        requestQueryParamsDataGridViewEnableColumn.HeaderText = "Enable";
        requestQueryParamsDataGridViewEnableColumn.Name = "requestQueryParamsDataGridViewEnableColumn";
        // 
        // requestQueryParamsDataGridViewKeyColumn
        // 
        requestQueryParamsDataGridViewKeyColumn.HeaderText = "Key";
        requestQueryParamsDataGridViewKeyColumn.Name = "requestQueryParamsDataGridViewKeyColumn";
        // 
        // requestQueryParamsDataGridViewValueColumn
        // 
        requestQueryParamsDataGridViewValueColumn.HeaderText = "Value";
        requestQueryParamsDataGridViewValueColumn.Name = "requestQueryParamsDataGridViewValueColumn";
        // 
        // sendRequestButton
        // 
        sendRequestButton.Location = new Point(657, 21);
        sendRequestButton.Name = "sendRequestButton";
        sendRequestButton.Size = new Size(109, 24);
        sendRequestButton.TabIndex = 2;
        sendRequestButton.Text = "Send";
        sendRequestButton.UseVisualStyleBackColor = true;
        // 
        // urlTextBox
        // 
        urlTextBox.Location = new Point(133, 22);
        urlTextBox.Name = "urlTextBox";
        urlTextBox.Size = new Size(522, 23);
        urlTextBox.TabIndex = 1;
        // 
        // methodsComboBox
        // 
        methodsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        methodsComboBox.Enabled = false;
        methodsComboBox.FormattingEnabled = true;
        methodsComboBox.Location = new Point(6, 22);
        methodsComboBox.Name = "methodsComboBox";
        methodsComboBox.Size = new Size(121, 23);
        methodsComboBox.TabIndex = 0;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(tabControl2);
        groupBox2.Controls.Add(responseResultLabel);
        groupBox2.Location = new Point(12, 454);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(774, 280);
        groupBox2.TabIndex = 3;
        groupBox2.TabStop = false;
        groupBox2.Text = "Response";
        // 
        // tabControl2
        // 
        tabControl2.Controls.Add(jsonResponseTab);
        tabControl2.Controls.Add(responseHeadersTab);
        tabControl2.Location = new Point(10, 36);
        tabControl2.Name = "tabControl2";
        tabControl2.SelectedIndex = 0;
        tabControl2.Size = new Size(756, 238);
        tabControl2.TabIndex = 2;
        // 
        // jsonResponseTab
        // 
        jsonResponseTab.Controls.Add(jsonResponseTextBox);
        jsonResponseTab.Location = new Point(4, 24);
        jsonResponseTab.Name = "jsonResponseTab";
        jsonResponseTab.Padding = new Padding(3);
        jsonResponseTab.Size = new Size(748, 210);
        jsonResponseTab.TabIndex = 0;
        jsonResponseTab.Text = "Body";
        jsonResponseTab.UseVisualStyleBackColor = true;
        // 
        // jsonResponseTextBox
        // 
        jsonResponseTextBox.Dock = DockStyle.Fill;
        jsonResponseTextBox.Location = new Point(3, 3);
        jsonResponseTextBox.Name = "jsonResponseTextBox";
        jsonResponseTextBox.Size = new Size(742, 204);
        jsonResponseTextBox.TabIndex = 0;
        jsonResponseTextBox.Text = "";
        // 
        // responseHeadersTab
        // 
        responseHeadersTab.Controls.Add(responseHeadersDataGridView);
        responseHeadersTab.Location = new Point(4, 24);
        responseHeadersTab.Name = "responseHeadersTab";
        responseHeadersTab.Padding = new Padding(3);
        responseHeadersTab.Size = new Size(748, 210);
        responseHeadersTab.TabIndex = 1;
        responseHeadersTab.Text = "Headers";
        responseHeadersTab.UseVisualStyleBackColor = true;
        // 
        // responseHeadersDataGridView
        // 
        responseHeadersDataGridView.AllowUserToAddRows = false;
        responseHeadersDataGridView.AllowUserToDeleteRows = false;
        responseHeadersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        responseHeadersDataGridView.Columns.AddRange(new DataGridViewColumn[] { responseHeadersDataGridViewKeyColumn, responseHeadersDataGridViewValueColumn });
        responseHeadersDataGridView.Dock = DockStyle.Fill;
        responseHeadersDataGridView.Location = new Point(3, 3);
        responseHeadersDataGridView.Name = "responseHeadersDataGridView";
        responseHeadersDataGridView.Size = new Size(742, 204);
        responseHeadersDataGridView.TabIndex = 1;
        // 
        // responseHeadersDataGridViewKeyColumn
        // 
        responseHeadersDataGridViewKeyColumn.HeaderText = "Key";
        responseHeadersDataGridViewKeyColumn.Name = "responseHeadersDataGridViewKeyColumn";
        // 
        // responseHeadersDataGridViewValueColumn
        // 
        responseHeadersDataGridViewValueColumn.HeaderText = "Value";
        responseHeadersDataGridViewValueColumn.Name = "responseHeadersDataGridViewValueColumn";
        // 
        // responseResultLabel
        // 
        responseResultLabel.BackColor = SystemColors.Window;
        responseResultLabel.Location = new Point(472, 11);
        responseResultLabel.Name = "responseResultLabel";
        responseResultLabel.Size = new Size(294, 23);
        responseResultLabel.TabIndex = 4;
        responseResultLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(requestDescriptionLabel);
        groupBox3.Controls.Add(collectionDescriptionLabel);
        groupBox3.Controls.Add(collectionComboBox);
        groupBox3.Controls.Add(requestComboBox);
        groupBox3.Controls.Add(label3);
        groupBox3.Controls.Add(label2);
        groupBox3.Location = new Point(10, 27);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(776, 80);
        groupBox3.TabIndex = 4;
        groupBox3.TabStop = false;
        groupBox3.Text = "Collections";
        // 
        // requestDescriptionLabel
        // 
        requestDescriptionLabel.Location = new Point(375, 51);
        requestDescriptionLabel.Name = "requestDescriptionLabel";
        requestDescriptionLabel.Size = new Size(391, 23);
        requestDescriptionLabel.TabIndex = 5;
        // 
        // collectionDescriptionLabel
        // 
        collectionDescriptionLabel.Location = new Point(86, 51);
        collectionDescriptionLabel.Name = "collectionDescriptionLabel";
        collectionDescriptionLabel.Size = new Size(210, 23);
        collectionDescriptionLabel.TabIndex = 4;
        // 
        // collectionComboBox
        // 
        collectionComboBox.FormattingEnabled = true;
        collectionComboBox.Location = new Point(86, 25);
        collectionComboBox.Name = "collectionComboBox";
        collectionComboBox.Size = new Size(210, 23);
        collectionComboBox.TabIndex = 3;
        // 
        // requestComboBox
        // 
        requestComboBox.FormattingEnabled = true;
        requestComboBox.Location = new Point(375, 25);
        requestComboBox.Name = "requestComboBox";
        requestComboBox.Size = new Size(391, 23);
        requestComboBox.TabIndex = 2;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(317, 28);
        label3.Name = "label3";
        label3.Size = new Size(52, 15);
        label3.TabIndex = 1;
        label3.Text = "Request:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(16, 28);
        label2.Name = "label2";
        label2.Size = new Size(64, 15);
        label2.TabIndex = 0;
        label2.Text = "Collection:";
        // 
        // menuStrip1
        // 
        menuStrip1.BackColor = SystemColors.Control;
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(797, 24);
        menuStrip1.TabIndex = 5;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.Size = new Size(98, 22);
        saveToolStripMenuItem.Text = "Save";
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(98, 22);
        exitToolStripMenuItem.Text = "Exit";
        // 
        // headerConfigurationsDataGridViewEnableColumn
        // 
        headerConfigurationsDataGridViewEnableColumn.HeaderText = "Enable";
        headerConfigurationsDataGridViewEnableColumn.Name = "headerConfigurationsDataGridViewEnableColumn";
        // 
        // headerConfigurationsDataGridViewKeyColumn
        // 
        headerConfigurationsDataGridViewKeyColumn.HeaderText = "Key";
        headerConfigurationsDataGridViewKeyColumn.Name = "headerConfigurationsDataGridViewKeyColumn";
        headerConfigurationsDataGridViewKeyColumn.ReadOnly = true;
        // 
        // headerConfigurationsDataGridViewValueColumn
        // 
        headerConfigurationsDataGridViewValueColumn.HeaderText = "Value";
        headerConfigurationsDataGridViewValueColumn.Name = "headerConfigurationsDataGridViewValueColumn";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Window;
        ClientSize = new Size(797, 736);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "Restman";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        tabControl1.ResumeLayout(false);
        requestHeadersTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)headerConfigurationDataGridView).EndInit();
        requestBodyTab.ResumeLayout(false);
        requestBodyTab.PerformLayout();
        bodyConfigurationTabControl.ResumeLayout(false);
        noBodyTab.ResumeLayout(false);
        noBodyTab.PerformLayout();
        jsonConfigurationTabPage.ResumeLayout(false);
        formDataConfigurationTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)formDataConfigurationDataGridView).EndInit();
        requestParamsTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)queryParameterConfigurationsDataGridView).EndInit();
        groupBox2.ResumeLayout(false);
        tabControl2.ResumeLayout(false);
        jsonResponseTab.ResumeLayout(false);
        responseHeadersTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)responseHeadersDataGridView).EndInit();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox groupBox1;
    private ComboBox methodsComboBox;
    private TextBox urlTextBox;
    private Button sendRequestButton;
    private GroupBox groupBox2;
    private RichTextBox jsonResponseTextBox;
    private Label responseResultLabel;
    private TabControl tabControl1;
    private TabPage requestParamsTab;
    private DataGridView queryParameterConfigurationsDataGridView;
    private TabPage requestHeadersTab;
    private DataGridView headerConfigurationDataGridView;
    private DataGridViewCheckBoxColumn requestQueryParamsDataGridViewEnableColumn;
    private DataGridViewTextBoxColumn requestQueryParamsDataGridViewKeyColumn;
    private DataGridViewTextBoxColumn requestQueryParamsDataGridViewValueColumn;
    private TabPage requestBodyTab;
    private TabControl tabControl2;
    private TabPage jsonResponseTab;
    private TabPage responseHeadersTab;
    private DataGridView responseHeadersDataGridView;
    private DataGridViewTextBoxColumn responseHeadersDataGridViewKeyColumn;
    private DataGridViewTextBoxColumn responseHeadersDataGridViewValueColumn;
    private TabControl bodyConfigurationTabControl;
    private TabPage noBodyTab;
    private TabPage jsonConfigurationTabPage;
    private Label label1;
    private RichTextBox jsonConfigurationTextBox;
    private TabPage formDataConfigurationTab;
    private RadioButton noRequestBodyRadioButton;
    private RadioButton jsonRequestBodyRadioButton;
    private RadioButton formDataRequestBodyRadioButton;
    private GroupBox groupBox3;
    private ComboBox collectionComboBox;
    private ComboBox requestComboBox;
    private Label label3;
    private Label label2;
    private Label requestDescriptionLabel;
    private Label collectionDescriptionLabel;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private DataGridView formDataConfigurationDataGridView;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private DataGridViewCheckBoxColumn requestBodyFormDataDataGridViewEnableColumn;
    private DataGridViewComboBoxColumn requestBodyFormDataDataGridViewComboBoxColumn;
    private DataGridViewTextBoxColumn requestBodyFormDataDataGridViewKeyColumn;
    private DataGridViewTextBoxColumn requestBodyFormDataDataGridViewValueColumn;
    private TabPage requestBodyNoneTab;
    private TabPage requestBodyJsonTab;
    private DataGridViewCheckBoxColumn headerConfigurationsDataGridViewEnableColumn;
    private DataGridViewTextBoxColumn headerConfigurationsDataGridViewKeyColumn;
    private DataGridViewTextBoxColumn headerConfigurationsDataGridViewValueColumn;
}
