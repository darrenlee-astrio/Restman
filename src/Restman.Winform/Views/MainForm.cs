using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restman.Application.Common.Formatters;
using Restman.Application.Common.Models.AppConfig;
using Restman.Application.Common.Models.AppData.Collections;
using Restman.Application.Common.Models.AppData.Configuration;
using Restman.Application.Common.Models.AppData.Request;
using Restman.Winform.Common.Extensions;
using Restman.Winform.Common.Helpers;
using Restman.Winform.Common.UiExtensions;
using Restman.Winform.Presenters;
using Restman.Winform.Views.Interfaces;

namespace Restman.Winform.Views;

public partial class MainForm : Form, IMainView
{
    private readonly ILogger<MainForm> _logger;
    private readonly LogForm _logForm;
    private readonly ResourcesConfiguration _resourcesConfiguration;
    private MainPresenter _presenter;

    public MainForm(
        ILogger<MainForm> logger,
        ILogger<MainPresenter> mainPresenterLogger,
        IOptions<ResourcesConfiguration> options,
        LogForm logForm,
        IMediator mediator)
    {
        _logger = logger;
        _logForm = logForm;
        _logForm.Show();
        _presenter = new MainPresenter(this, mediator, mainPresenterLogger);
        _resourcesConfiguration = options.Value;

        InitializeComponent();
        Init();
    }

    private void Init()
    {
        LoadCollections();

        #region Events Initialisation
        sendRequestButton.Click += (sender, e) => SendClicked?.Invoke(this, EventArgs.Empty);
        urlTextBox.KeyPress += (sender, e) => { e.Handled = true; };
        urlTextBox.TextChanged += (sender, e) => { Url = urlTextBox.Text; };
        queryParameterConfigurationsDataGridView.CellValueChanged += (sender, e) =>
        {
            OnRequestQueryParameterChanged?.Invoke(this, EventArgs.Empty);
        };
        queryParameterConfigurationsDataGridView.CurrentCellDirtyStateChanged += (sender, e) =>
        {
            if (queryParameterConfigurationsDataGridView.IsCurrentCellDirty)
            {
                queryParameterConfigurationsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        };
        headerConfigurationDataGridView.CellValueChanged += (sender, e) =>
        {
            OnHeaderConfigurationChanged?.Invoke(this, EventArgs.Empty);
        };
        headerConfigurationDataGridView.CurrentCellDirtyStateChanged += (sender, e) =>
        {
            if (headerConfigurationDataGridView.IsCurrentCellDirty)
            {
                headerConfigurationDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        };

        jsonConfigurationTextBox.TextChanged += (sender, e) => { JsonConfiguration = jsonConfigurationTextBox.Text; };
        collectionComboBox.SelectedIndexChanged += (sender, e) => { SelectedCollectionName = collectionComboBox.Text; };
        requestComboBox.SelectedIndexChanged += (sender, e) => { SelectedRequestName = requestComboBox.Text; };
        methodsComboBox.SelectedIndexChanged += (sender, e) => { Method = methodsComboBox.Text; };
        noRequestBodyRadioButton.CheckedChanged += (sender, e) => { bodyConfigurationTabControl.SelectedIndex = 0; };
        jsonRequestBodyRadioButton.CheckedChanged += (sender, e) => { bodyConfigurationTabControl.SelectedIndex = 1; };
        formDataRequestBodyRadioButton.CheckedChanged += (sender, e) => { bodyConfigurationTabControl.SelectedIndex = 2; };
        #endregion

        //httpMethodsComboBox.Initialize(HttpMethodExtensions.GetAllHttpMethods());
        methodsComboBox.Initialize(new[] { "GET", "POST", "PUT", "DELETE" });
        queryParameterConfigurationsDataGridView.Initialize(0.1, 0.45, 0.45);
        headerConfigurationDataGridView.Initialize(0.1, 0.45, 0.45);
        responseHeadersDataGridView.Initialize(0.3, 0.7);
        bodyConfigurationTabControl.ItemSize = new Size(0, 1);
        bodyConfigurationTabControl.SizeMode = TabSizeMode.Fixed;

        saveToolStripMenuItem.Click += (sender, e) => { SaveChanges(); };
        exitToolStripMenuItem.Click += (sender, e) => { this.Close(); };
        FormClosing += (sender, e) =>
        {
            _presenter.Cleanup();

            if (HasUnsavedChanges)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveChanges();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        };
    }

    private void LoadCollections()
    {
        try
        {
            Collections = YamlHelper.Deserialize<List<RequestCollection>>(_resourcesConfiguration.CollectionsFilePath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred when loading collections.");
            MessageBox.Show($"An error occurred when loading collections. \n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }

    private void SaveChanges()
    {
        try
        {
            var selectedCollectionIndex = Collections.FindIndex(x => x.Name == SelectedCollection.Name);
            var selectedRequestIndex = SelectedCollection.Requests.FindIndex(x => x.Name == SelectedRequest.Name);

            SelectedCollection.Requests[selectedRequestIndex] = SelectedRequest;
            Collections[selectedCollectionIndex] = SelectedCollection;

            string yaml = YamlHelper.Serialize(Collections);
            File.WriteAllText(_resourcesConfiguration.CollectionsFilePath, yaml);

            SavedQueryParameterConfigurations = QueryParameterConfigurations;
            SavedHeaderConfigurations = HeaderConfigurations;
            SavedJsonConfiguration = JsonConfiguration;
            SavedFormDataConfigurations = FormDataConfigurations;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred when saving collections.");
            MessageBox.Show($"An error occurred when loading collections. \n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }

    #region IMainView Properties
    private List<RequestCollection> _collections = new();
    private List<RequestItem> _requests = new();
    private RequestCollection _selectedCollection = new();
    private RequestItem _selectedRequest = new();
    private string _selectedRequestName = string.Empty;
    private bool _isRequestSending = false;
    private bool _isRequestCompleted = false;

    private List<HeaderConfiguration> _savedHeaderConfigurations = new();
    private List<QueryParameterConfiguration> _savedQueryParameterConfigurations = new();
    private string _savedJsonConfiguration = string.Empty;
    private List<FormDataConfiguration> _savedFormDataConfiguration = new();

    public bool HasUnsavedChanges
    {
        get
        {
            return HeaderConfigurationsChanged
                || QueryParameterConfigurationsChanged
                || JsonConfigurationChanged
                || FormDataConfigurationChanged;
        }
    }
    public bool HeaderConfigurationsChanged { get => !SavedHeaderConfigurations.SequenceEqual(HeaderConfigurations); }
    public bool QueryParameterConfigurationsChanged { get => !SavedQueryParameterConfigurations.SequenceEqual(QueryParameterConfigurations); }
    public bool JsonConfigurationChanged { get => !SavedJsonConfiguration.Equals(JsonConfiguration); }
    public bool FormDataConfigurationChanged { get => !SavedFormDataConfigurations.SequenceEqual(FormDataConfigurations); }

    public List<QueryParameterConfiguration> SavedQueryParameterConfigurations
    {
        get { return _savedQueryParameterConfigurations; }
        set { _savedQueryParameterConfigurations = new List<QueryParameterConfiguration>(value); }
    }
    public List<HeaderConfiguration> SavedHeaderConfigurations
    {
        get { return _savedHeaderConfigurations; }
        set { _savedHeaderConfigurations = new List<HeaderConfiguration>(value); }
    }
    public string SavedJsonConfiguration
    {
        get { return _savedJsonConfiguration; }
        set { _savedJsonConfiguration = value; }
    }
    public List<FormDataConfiguration> SavedFormDataConfigurations
    {
        get { return _savedFormDataConfiguration; }
        set { _savedFormDataConfiguration = new List<FormDataConfiguration>(value); }
    }
    public List<RequestCollection> Collections
    {
        get { return _collections; }
        set
        {
            if (value is not null
                && value.Count > 0
                && _collections != value)
            {
                _collections = value;
                OnCollectionsChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public List<RequestItem> Requests
    {
        get { return _requests; }
        set { _requests = value; }
    }
    public RequestCollection SelectedCollection
    {
        get { return _selectedCollection; }
        set
        {
            _selectedCollection = value;
        }
    }
    public RequestItem SelectedRequest
    {
        get { return _selectedRequest; }
        set { _selectedRequest = value; }
    }
    public List<string> CollectionNames
    {
        get { return collectionComboBox.Items.Cast<string>().ToList(); }
        set
        {
            collectionComboBox.InvokeIfRequired(comboBox =>
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange(value.ToArray());
            });

        }
    }
    public List<string> RequestNames
    {
        get { return requestComboBox.Items.Cast<string>().ToList(); }
        set
        {
            requestComboBox.InvokeIfRequired(comboBox =>
            {
                comboBox.Items.Clear();
                comboBox.Items.AddRange(value.ToArray());
            });
        }
    }
    public string SelectedCollectionName
    {
        get { return collectionComboBox.Text; }
        set
        {
            collectionComboBox.InvokeIfRequired(comboBox => comboBox.SelectItemByText(value));
            OnSelectedCollectionNameChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public string SelectedRequestName
    {
        get { return requestComboBox.Text; }
        set
        {
            if (_selectedRequestName == value)
            {
                return;
            }
            _selectedRequestName = value;
            requestComboBox.InvokeIfRequired(comboBox => comboBox.SelectItemByText(_selectedRequestName));
            OnSelectedRequestNameChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public string SelectedCollectionDescription
    {
        get { return collectionDescriptionLabel.Text; }
        set { collectionDescriptionLabel.InvokeIfRequired(label => label.Text = value); }
    }
    public string SelectedRequestDescription
    {
        get { return requestDescriptionLabel.Text; }
        set { requestDescriptionLabel.InvokeIfRequired(label => label.Text = value); }
    }
    public string Method
    {
        get => methodsComboBox.Text;
        set
        {
            methodsComboBox.InvokeIfRequired(comboBox => comboBox.SelectedIndex = methodsComboBox.FindString(value));
            OnRequestMethodChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public string Url
    {
        get { return urlTextBox.Text; }
        set { urlTextBox.InvokeIfRequired(textBox => textBox.Text = value); }
    }
    public string SelectedRequestFullUrl
    {
        get { return UrlFormatter.Combine(SelectedCollection.BaseUrl, SelectedRequest.EndUrl); }
    }
    public List<QueryParameterConfiguration> QueryParameterConfigurations
    {
        get { return queryParameterConfigurationsDataGridView.GetData<QueryParameterConfiguration>(); }
        set
        {
            queryParameterConfigurationsDataGridView.InvokeIfRequired(gridView =>
            {
                gridView.Rows.Clear();
                foreach (QueryParameterConfiguration row in value)
                {
                    gridView.Rows.Add(row.Enable, row.Key, row.Value);
                }
            });
            SelectedRequest.QueryParameterConfigurations = value;
        }
    }
    public List<HeaderConfiguration> HeaderConfigurations
    {
        get
        {
            return headerConfigurationDataGridView.GetData<HeaderConfiguration>();
        }
        set
        {
            headerConfigurationDataGridView.InvokeIfRequired(gridView =>
            {
                gridView.Rows.Clear();
                foreach (HeaderConfiguration row in value)
                {
                    gridView.Rows.Add(row.Enable, row.Key, row.Value);
                }
            });
            SelectedRequest.HeaderConfigurations = value;
        }
    }
    public List<FormDataConfiguration> FormDataConfigurations
    {
        get { return formDataConfigurationDataGridView.GetData<FormDataConfiguration>(); }
        set
        {
            formDataConfigurationDataGridView.InvokeIfRequired(gridView =>
            {
                gridView.Rows.Clear();
                foreach (FormDataConfiguration row in value)
                {
                    gridView.Rows.Add(row.Enable, row.Type, row.Key, row.Value);
                }
            });
        }
    }
    public bool HasNoBody
    {
        get { return noRequestBodyRadioButton.Checked; }
        set
        {
            noRequestBodyRadioButton.InvokeIfRequired(button =>
            {
                button.Checked = value;
                button.Enabled = value;
            });

            if (value)
            {
                OnRequestBodyTypeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public bool HasJsonBody
    {
        get { return jsonRequestBodyRadioButton.Checked; }
        set
        {
            jsonRequestBodyRadioButton.InvokeIfRequired(button =>
            {
                button.Checked = value;
                button.Enabled = value;
            });

            if (value)
            {
                OnRequestBodyTypeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public bool HasFormData
    {
        get { return formDataRequestBodyRadioButton.Checked; }
        set
        {
            formDataRequestBodyRadioButton.InvokeIfRequired(button =>
            {
                button.Checked = value;
                button.Enabled = value;
            });

            if (value)
            {
                OnRequestBodyTypeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public string JsonConfiguration
    {
        get { return jsonConfigurationTextBox.Text; }
        set
        {
            jsonConfigurationTextBox.InvokeIfRequired(textBox => textBox.Text = value);
            SelectedRequest.JsonConfiguration = value;
        }
    }
    public string Result
    {
        get { return responseResultLabel.Text; }
        set { responseResultLabel.InvokeIfRequired(textBox => textBox.Text = value); }
    }
    public string? JsonResponse
    {
        get { return jsonResponseTextBox.Text; }
        set { jsonResponseTextBox.InvokeIfRequired(textBox => textBox.Text = value); }
    }
    public List<KeyValueConfiguration> ResponseHeaders
    {
        get { return responseHeadersDataGridView.GetData<KeyValueConfiguration>(); }
        set
        {
            responseHeadersDataGridView.InvokeIfRequired(gridView =>
            {
                gridView.Rows.Clear();
                foreach (KeyValueConfiguration row in value)
                {
                    gridView.Rows.Add(row.Key, row.Value);
                }
            });
        }
    }
    public bool IsRequestSending
    {
        get { return _isRequestSending; }
        set
        {
            _isRequestSending = value;

            if (_isRequestSending)
            {
                OnRequestSending?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public bool IsRequestCompleted
    {
        get { return _isRequestCompleted; }
        set
        {
            _isRequestCompleted = value;

            if (_isRequestSending)
            {
                OnRequestCompleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public string SendHttpRequestButtonText
    {
        get { return sendRequestButton.Text; }
        set { sendRequestButton.InvokeIfRequired(button => button.Text = value); }
    }
    #endregion

    #region Events
    public event EventHandler? OnCollectionsChanged;
    public event EventHandler? OnSelectedCollectionNameChanged;
    public event EventHandler? OnSelectedRequestNameChanged;
    public event EventHandler? OnRequestMethodChanged;
    public event EventHandler? OnRequestBodyTypeChanged;
    public event EventHandler? OnRequestQueryParameterChanged;
    public event EventHandler? OnHeaderConfigurationChanged;

    public event EventHandler? OnRequestSending;
    public event EventHandler? OnRequestCompleted;
    public event EventHandler? SendClicked;
    #endregion
}
