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
        requestParamsTab = new TabPage();
        queryParamsLabel = new Label();
        requestQueryParamsDataGridView = new DataGridView();
        requestQueryParamsDataGridViewEnableColumn = new DataGridViewCheckBoxColumn();
        requestQueryParamsDataGridViewKeyColumn = new DataGridViewTextBoxColumn();
        requestQueryParamsDataGridViewValueColumn = new DataGridViewTextBoxColumn();
        requestHeadersTab = new TabPage();
        headersLabel = new Label();
        requestHeadersDataGridView = new DataGridView();
        requestHeadersDataGridViewEnableColumn = new DataGridViewCheckBoxColumn();
        requestHeadersDataGridViewKeyColumn = new DataGridViewTextBoxColumn();
        requestHeadersDataGridViewValueColumn = new DataGridViewTextBoxColumn();
        requestBodyTab = new TabPage();
        formDataRequestBodyRadioButton = new RadioButton();
        jsonRequestBodyRadioButton = new RadioButton();
        noRequestBodyRadioButton = new RadioButton();
        requestBodyTabControl = new TabControl();
        requestBodyNoneTab = new TabPage();
        label1 = new Label();
        requestBodyJsonTab = new TabPage();
        requestBodyJsonTextBox = new RichTextBox();
        requestBodyFormDataTab = new TabPage();
        sendHttpRequestButton = new Button();
        urlTextBox = new TextBox();
        httpMethodsComboBox = new ComboBox();
        groupBox2 = new GroupBox();
        tabControl2 = new TabControl();
        responseBodyTab = new TabPage();
        httpResponseTextBox = new RichTextBox();
        responseHeadersTab = new TabPage();
        responseHeadersDataGridView = new DataGridView();
        responseHeadersDataGridViewKeyColumn = new DataGridViewTextBoxColumn();
        responseHeadersDataGridViewValueColumn = new DataGridViewTextBoxColumn();
        httpResponseResultLabel = new Label();
        groupBox3 = new GroupBox();
        requestDescriptionLabel = new Label();
        collectionDescriptionLabel = new Label();
        collectionComboBox = new ComboBox();
        requestComboBox = new ComboBox();
        label3 = new Label();
        label2 = new Label();
        groupBox1.SuspendLayout();
        tabControl1.SuspendLayout();
        requestParamsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)requestQueryParamsDataGridView).BeginInit();
        requestHeadersTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)requestHeadersDataGridView).BeginInit();
        requestBodyTab.SuspendLayout();
        requestBodyTabControl.SuspendLayout();
        requestBodyNoneTab.SuspendLayout();
        requestBodyJsonTab.SuspendLayout();
        groupBox2.SuspendLayout();
        tabControl2.SuspendLayout();
        responseBodyTab.SuspendLayout();
        responseHeadersTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)responseHeadersDataGridView).BeginInit();
        groupBox3.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(tabControl1);
        groupBox1.Controls.Add(sendHttpRequestButton);
        groupBox1.Controls.Add(urlTextBox);
        groupBox1.Controls.Add(httpMethodsComboBox);
        groupBox1.Location = new Point(12, 98);
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
        // requestParamsTab
        // 
        requestParamsTab.Controls.Add(queryParamsLabel);
        requestParamsTab.Controls.Add(requestQueryParamsDataGridView);
        requestParamsTab.Location = new Point(4, 24);
        requestParamsTab.Name = "requestParamsTab";
        requestParamsTab.Padding = new Padding(3);
        requestParamsTab.Size = new Size(756, 250);
        requestParamsTab.TabIndex = 0;
        requestParamsTab.Text = "Params";
        requestParamsTab.UseVisualStyleBackColor = true;
        // 
        // queryParamsLabel
        // 
        queryParamsLabel.AutoSize = true;
        queryParamsLabel.Location = new Point(6, 12);
        queryParamsLabel.Name = "queryParamsLabel";
        queryParamsLabel.Size = new Size(101, 15);
        queryParamsLabel.TabIndex = 1;
        queryParamsLabel.Text = "Query Parameters";
        // 
        // requestQueryParamsDataGridView
        // 
        requestQueryParamsDataGridView.AllowUserToAddRows = false;
        requestQueryParamsDataGridView.AllowUserToDeleteRows = false;
        requestQueryParamsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        requestQueryParamsDataGridView.Columns.AddRange(new DataGridViewColumn[] { requestQueryParamsDataGridViewEnableColumn, requestQueryParamsDataGridViewKeyColumn, requestQueryParamsDataGridViewValueColumn });
        requestQueryParamsDataGridView.Location = new Point(6, 44);
        requestQueryParamsDataGridView.Name = "requestQueryParamsDataGridView";
        requestQueryParamsDataGridView.Size = new Size(744, 200);
        requestQueryParamsDataGridView.TabIndex = 0;
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
        // requestHeadersTab
        // 
        requestHeadersTab.Controls.Add(headersLabel);
        requestHeadersTab.Controls.Add(requestHeadersDataGridView);
        requestHeadersTab.Location = new Point(4, 24);
        requestHeadersTab.Name = "requestHeadersTab";
        requestHeadersTab.Padding = new Padding(3);
        requestHeadersTab.Size = new Size(756, 250);
        requestHeadersTab.TabIndex = 1;
        requestHeadersTab.Text = "Headers";
        requestHeadersTab.UseVisualStyleBackColor = true;
        // 
        // headersLabel
        // 
        headersLabel.AutoSize = true;
        headersLabel.Location = new Point(6, 12);
        headersLabel.Name = "headersLabel";
        headersLabel.Size = new Size(50, 15);
        headersLabel.TabIndex = 2;
        headersLabel.Text = "Headers";
        // 
        // requestHeadersDataGridView
        // 
        requestHeadersDataGridView.AllowUserToAddRows = false;
        requestHeadersDataGridView.AllowUserToDeleteRows = false;
        requestHeadersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        requestHeadersDataGridView.Columns.AddRange(new DataGridViewColumn[] { requestHeadersDataGridViewEnableColumn, requestHeadersDataGridViewKeyColumn, requestHeadersDataGridViewValueColumn });
        requestHeadersDataGridView.Location = new Point(6, 44);
        requestHeadersDataGridView.Name = "requestHeadersDataGridView";
        requestHeadersDataGridView.Size = new Size(744, 200);
        requestHeadersDataGridView.TabIndex = 1;
        // 
        // requestHeadersDataGridViewEnableColumn
        // 
        requestHeadersDataGridViewEnableColumn.HeaderText = "Enable";
        requestHeadersDataGridViewEnableColumn.Name = "requestHeadersDataGridViewEnableColumn";
        // 
        // requestHeadersDataGridViewKeyColumn
        // 
        requestHeadersDataGridViewKeyColumn.HeaderText = "Key";
        requestHeadersDataGridViewKeyColumn.Name = "requestHeadersDataGridViewKeyColumn";
        // 
        // requestHeadersDataGridViewValueColumn
        // 
        requestHeadersDataGridViewValueColumn.HeaderText = "Value";
        requestHeadersDataGridViewValueColumn.Name = "requestHeadersDataGridViewValueColumn";
        // 
        // requestBodyTab
        // 
        requestBodyTab.Controls.Add(formDataRequestBodyRadioButton);
        requestBodyTab.Controls.Add(jsonRequestBodyRadioButton);
        requestBodyTab.Controls.Add(noRequestBodyRadioButton);
        requestBodyTab.Controls.Add(requestBodyTabControl);
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
        // requestBodyTabControl
        // 
        requestBodyTabControl.Controls.Add(requestBodyNoneTab);
        requestBodyTabControl.Controls.Add(requestBodyJsonTab);
        requestBodyTabControl.Controls.Add(requestBodyFormDataTab);
        requestBodyTabControl.ItemSize = new Size(0, 1);
        requestBodyTabControl.Location = new Point(0, 36);
        requestBodyTabControl.Name = "requestBodyTabControl";
        requestBodyTabControl.SelectedIndex = 0;
        requestBodyTabControl.Size = new Size(756, 214);
        requestBodyTabControl.SizeMode = TabSizeMode.Fixed;
        requestBodyTabControl.TabIndex = 0;
        // 
        // requestBodyNoneTab
        // 
        requestBodyNoneTab.BackColor = Color.LightGray;
        requestBodyNoneTab.Controls.Add(label1);
        requestBodyNoneTab.Location = new Point(4, 5);
        requestBodyNoneTab.Name = "requestBodyNoneTab";
        requestBodyNoneTab.Padding = new Padding(3);
        requestBodyNoneTab.Size = new Size(748, 205);
        requestBodyNoneTab.TabIndex = 0;
        requestBodyNoneTab.Text = "None";
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Location = new Point(277, 98);
        label1.Name = "label1";
        label1.Size = new Size(189, 15);
        label1.TabIndex = 0;
        label1.Text = "This request does not have a body.";
        // 
        // requestBodyJsonTab
        // 
        requestBodyJsonTab.Controls.Add(requestBodyJsonTextBox);
        requestBodyJsonTab.Location = new Point(4, 5);
        requestBodyJsonTab.Name = "requestBodyJsonTab";
        requestBodyJsonTab.Padding = new Padding(3);
        requestBodyJsonTab.Size = new Size(748, 205);
        requestBodyJsonTab.TabIndex = 1;
        requestBodyJsonTab.Text = "Json";
        requestBodyJsonTab.UseVisualStyleBackColor = true;
        // 
        // requestBodyJsonTextBox
        // 
        requestBodyJsonTextBox.Dock = DockStyle.Fill;
        requestBodyJsonTextBox.Location = new Point(3, 3);
        requestBodyJsonTextBox.Name = "requestBodyJsonTextBox";
        requestBodyJsonTextBox.Size = new Size(742, 199);
        requestBodyJsonTextBox.TabIndex = 0;
        requestBodyJsonTextBox.Text = "";
        // 
        // requestBodyFormDataTab
        // 
        requestBodyFormDataTab.Location = new Point(4, 5);
        requestBodyFormDataTab.Name = "requestBodyFormDataTab";
        requestBodyFormDataTab.Size = new Size(748, 205);
        requestBodyFormDataTab.TabIndex = 2;
        requestBodyFormDataTab.Text = "Form-Data";
        requestBodyFormDataTab.UseVisualStyleBackColor = true;
        // 
        // sendHttpRequestButton
        // 
        sendHttpRequestButton.Location = new Point(657, 21);
        sendHttpRequestButton.Name = "sendHttpRequestButton";
        sendHttpRequestButton.Size = new Size(109, 24);
        sendHttpRequestButton.TabIndex = 2;
        sendHttpRequestButton.Text = "Send";
        sendHttpRequestButton.UseVisualStyleBackColor = true;
        // 
        // urlTextBox
        // 
        urlTextBox.Location = new Point(133, 22);
        urlTextBox.Name = "urlTextBox";
        urlTextBox.Size = new Size(522, 23);
        urlTextBox.TabIndex = 1;
        // 
        // httpMethodsComboBox
        // 
        httpMethodsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        httpMethodsComboBox.Enabled = false;
        httpMethodsComboBox.FormattingEnabled = true;
        httpMethodsComboBox.Location = new Point(6, 22);
        httpMethodsComboBox.Name = "httpMethodsComboBox";
        httpMethodsComboBox.Size = new Size(121, 23);
        httpMethodsComboBox.TabIndex = 0;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(tabControl2);
        groupBox2.Controls.Add(httpResponseResultLabel);
        groupBox2.Location = new Point(12, 439);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(776, 280);
        groupBox2.TabIndex = 3;
        groupBox2.TabStop = false;
        groupBox2.Text = "Response";
        // 
        // tabControl2
        // 
        tabControl2.Controls.Add(responseBodyTab);
        tabControl2.Controls.Add(responseHeadersTab);
        tabControl2.Location = new Point(10, 36);
        tabControl2.Name = "tabControl2";
        tabControl2.SelectedIndex = 0;
        tabControl2.Size = new Size(756, 238);
        tabControl2.TabIndex = 2;
        // 
        // responseBodyTab
        // 
        responseBodyTab.Controls.Add(httpResponseTextBox);
        responseBodyTab.Location = new Point(4, 24);
        responseBodyTab.Name = "responseBodyTab";
        responseBodyTab.Padding = new Padding(3);
        responseBodyTab.Size = new Size(748, 210);
        responseBodyTab.TabIndex = 0;
        responseBodyTab.Text = "Body";
        responseBodyTab.UseVisualStyleBackColor = true;
        // 
        // httpResponseTextBox
        // 
        httpResponseTextBox.Dock = DockStyle.Fill;
        httpResponseTextBox.Location = new Point(3, 3);
        httpResponseTextBox.Name = "httpResponseTextBox";
        httpResponseTextBox.Size = new Size(742, 204);
        httpResponseTextBox.TabIndex = 0;
        httpResponseTextBox.Text = "";
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
        // httpResponseResultLabel
        // 
        httpResponseResultLabel.BackColor = SystemColors.Control;
        httpResponseResultLabel.Location = new Point(472, 10);
        httpResponseResultLabel.Name = "httpResponseResultLabel";
        httpResponseResultLabel.Size = new Size(294, 23);
        httpResponseResultLabel.TabIndex = 1;
        httpResponseResultLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(requestDescriptionLabel);
        groupBox3.Controls.Add(collectionDescriptionLabel);
        groupBox3.Controls.Add(collectionComboBox);
        groupBox3.Controls.Add(requestComboBox);
        groupBox3.Controls.Add(label3);
        groupBox3.Controls.Add(label2);
        groupBox3.Location = new Point(12, 12);
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
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(797, 731);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "MainForm";
        Text = "Restman";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        tabControl1.ResumeLayout(false);
        requestParamsTab.ResumeLayout(false);
        requestParamsTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)requestQueryParamsDataGridView).EndInit();
        requestHeadersTab.ResumeLayout(false);
        requestHeadersTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)requestHeadersDataGridView).EndInit();
        requestBodyTab.ResumeLayout(false);
        requestBodyTab.PerformLayout();
        requestBodyTabControl.ResumeLayout(false);
        requestBodyNoneTab.ResumeLayout(false);
        requestBodyNoneTab.PerformLayout();
        requestBodyJsonTab.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        tabControl2.ResumeLayout(false);
        responseBodyTab.ResumeLayout(false);
        responseHeadersTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)responseHeadersDataGridView).EndInit();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox groupBox1;
    private ComboBox httpMethodsComboBox;
    private TextBox urlTextBox;
    private Button sendHttpRequestButton;
    private GroupBox groupBox2;
    private RichTextBox httpResponseTextBox;
    private Label httpResponseResultLabel;
    private TabControl tabControl1;
    private TabPage requestParamsTab;
    private DataGridView requestQueryParamsDataGridView;
    private TabPage requestHeadersTab;
    private Label queryParamsLabel;
    private DataGridView requestHeadersDataGridView;
    private Label headersLabel;
    private DataGridViewCheckBoxColumn requestQueryParamsDataGridViewEnableColumn;
    private DataGridViewTextBoxColumn requestQueryParamsDataGridViewKeyColumn;
    private DataGridViewTextBoxColumn requestQueryParamsDataGridViewValueColumn;
    private DataGridViewCheckBoxColumn requestHeadersDataGridViewEnableColumn;
    private DataGridViewTextBoxColumn requestHeadersDataGridViewKeyColumn;
    private DataGridViewTextBoxColumn requestHeadersDataGridViewValueColumn;
    private TabPage requestBodyTab;
    private TabControl tabControl2;
    private TabPage responseBodyTab;
    private TabPage responseHeadersTab;
    private DataGridView responseHeadersDataGridView;
    private DataGridViewTextBoxColumn responseHeadersDataGridViewKeyColumn;
    private DataGridViewTextBoxColumn responseHeadersDataGridViewValueColumn;
    private TabControl requestBodyTabControl;
    private TabPage requestBodyNoneTab;
    private TabPage requestBodyJsonTab;
    private Label label1;
    private RichTextBox requestBodyJsonTextBox;
    private TabPage requestBodyFormDataTab;
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
}
