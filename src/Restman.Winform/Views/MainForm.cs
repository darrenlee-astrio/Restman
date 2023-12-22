using MediatR;
using Microsoft.Extensions.Logging;
using Restman.Application.Common.Models;
using Restman.Winform.Common.Extensions;
using Restman.Winform.Common.Helpers;
using Restman.Winform.Common.Models;
using Restman.Winform.Common.UiExtensions;
using Restman.Winform.Presenters;
using Restman.Winform.Views.Interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Restman.Winform.Views;

public partial class MainForm : Form, IMainView
{
    private readonly ILogger<MainForm> _logger;
    private readonly LogForm _logForm;
    private MainPresenter _presenter;

    public MainForm(
        ILogger<MainForm> logger,
        ILogger<MainPresenter> mainPresenterLogger,
        LogForm logForm,
        IMediator mediator)
    {
        InitializeComponent();

        _logger = logger;
        _logForm = logForm;
        _logForm.Show();

        _presenter = new MainPresenter(this, mediator, mainPresenterLogger);

        Init();
    }

    public void Test()
    {
        var collection = new RequestCollection
        {
            Name = "Reqres",
            BaseUrl = "https://reqres.in",
            Requests = new List<RequestItem>
            {
                new RequestItem
                {
                    Name = "Get Users",
                    Method = $"{HttpMethod.Get}",
                    EndUrl = "/api/users",
                    Description = "Gets all users from API"
                },
                new RequestItem
                {
                    Name = "Get Users With Delay",
                    Method = $"{HttpMethod.Get}",
                    EndUrl = "/api/users?delay=3",
                    Description = "Gets all users from API with 3 seconds delay"
                },
                new RequestItem
                {
                    Name = "Get Single User",
                    Method = $"{HttpMethod.Get}",
                    EndUrl = "/api/users/1",
                    Description = "Gets a single user by id"
                },
                new RequestItem
                {
                    Name = "Create User",
                    Method = $"{HttpMethod.Post}",
                    EndUrl = "/api/users",
                    Description = "Creates a user",
                    JsonContent = """
                    {
                      "name": "morpheus",
                      "job": "leader"
                    }
                    """
                },
                new RequestItem
                {
                    Name = "Update User",
                    Method = $"{HttpMethod.Put}",
                    EndUrl = "/api/users/1",
                    Description = "Update a user by id",
                    JsonContent = """
                    {
                      "name": "morpheus",
                      "job": "employee"
                    }
                    """
                },
                new RequestItem
                {
                    Name = "Delete User",
                    Method = $"{HttpMethod.Delete}",
                    EndUrl = "/api/users/1",
                    Description = "Creates a user"
                }
            }
        };
    }

    private void Init()
    {
        LoadCollections();

        #region Events Initialisation
        sendHttpRequestButton.Click += (sender, e) => SendClicked?.Invoke(this, EventArgs.Empty);

        this.FormClosing += (sender, e) => { _presenter.Cleanup(); };

        urlTextBox.TextChanged += (sender, e) => { Url = urlTextBox.Text; };
        requestBodyJsonTextBox.TextChanged += (sender, e) => { RequestBodyJson = requestBodyJsonTextBox.Text; };
        collectionComboBox.SelectedIndexChanged += (sender, e) => { SelectedCollectionName = collectionComboBox.Text; };
        requestComboBox.SelectedIndexChanged += (sender, e) => { SelectedRequestName = requestComboBox.Text; };
        httpMethodsComboBox.SelectedIndexChanged += (sender, e) => { Method = httpMethodsComboBox.Text; };
        noRequestBodyRadioButton.CheckedChanged += (sender, e) => { requestBodyTabControl.SelectedIndex = 0; };
        jsonRequestBodyRadioButton.CheckedChanged += (sender, e) => { requestBodyTabControl.SelectedIndex = 1; };
        formDataRequestBodyRadioButton.CheckedChanged += (sender, e) => { requestBodyTabControl.SelectedIndex = 2; };
        #endregion

        //httpMethodsComboBox.Initialize(HttpMethodExtensions.GetAllHttpMethods());
        httpMethodsComboBox.Initialize(new[] { "GET", "POST", "PUT", "DELETE" });
        requestQueryParamsDataGridView.Initialize(0.1, 0.45, 0.45);
        requestHeadersDataGridView.Initialize(0.1, 0.45, 0.45);
        responseHeadersDataGridView.Initialize(0.3, 0.7);
    }

    private void LoadCollections()
    {
        try
        {
            Collections = YamlHelper.Deserialize<List<RequestCollection>>("Resources\\collections.yml");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred when loading collections.");
        }
    }

    #region Properties

    private List<RequestCollection> _collections = new();
    private List<RequestItem> _requests = new();
    private RequestCollection _selectedCollection = new();
    private RequestItem _selectedRequest = new();
    private string _selectedRequestName = string.Empty;
    private bool _isRequestSending = false;
    private bool _isRequestCompleted = false;

    
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
        get => httpMethodsComboBox.Text;
        set
        {
            httpMethodsComboBox.InvokeIfRequired(comboBox => comboBox.SelectedIndex = httpMethodsComboBox.FindString(value));
            OnRequestMethodChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public string Url
    {
        get { return urlTextBox.Text; }
        set { urlTextBox.InvokeIfRequired(textBox => textBox.Text = value); }
    }
    public string? Content
    {
        get { return requestBodyJsonTextBox.Text; }
        set { requestBodyJsonTextBox.InvokeIfRequired(textBox => textBox.Text = value); }
    }
    public List<KeyValueTwinWithEnable> RequestQueryParameters
    {
        get { return requestQueryParamsDataGridView.GetData<KeyValueTwinWithEnable>(); }
        set
        {
            requestQueryParamsDataGridView.InvokeIfRequired(gridView =>
            {
                gridView.Rows.Clear();
                foreach (KeyValueTwinWithEnable row in value)
                {
                    gridView.Rows.Add(row.Enable, row.Key, row.Value);
                }
            });
        }
    }
    public List<KeyValueTwinWithEnable> RequestHeaders
    {
        get { return requestHeadersDataGridView.GetData<KeyValueTwinWithEnable>(); }
        set
        {
            requestHeadersDataGridView.InvokeIfRequired(gridView =>
            {
                gridView.Rows.Clear();
                foreach (KeyValueTwinWithEnable row in value)
                {
                    gridView.Rows.Add(row.Enable, row.Key, row.Value);
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
    public string? RequestBodyJson
    {
        get { return requestBodyJsonTextBox.Text; }
        set { requestBodyJsonTextBox.InvokeIfRequired(textBox => textBox.Text = value); }
    }
    public string Result
    {
        get { return httpResponseResultLabel.Text; }
        set { httpResponseResultLabel.InvokeIfRequired(textBox => textBox.Text = value); }
    }
    public string? ResponseBodyJson
    {
        get { return httpResponseTextBox.Text; }
        set { httpResponseTextBox.InvokeIfRequired(textBox => textBox.Text = value); }
    }
    public List<KeyValueTwin> ResponseHeaders
    {
        get { return responseHeadersDataGridView.GetData<KeyValueTwin>(); }
        set
        {
            responseHeadersDataGridView.InvokeIfRequired(gridView =>
            {
                gridView.Rows.Clear();
                foreach (KeyValueTwin row in value)
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
        get { return sendHttpRequestButton.Text; }
        set { sendHttpRequestButton.InvokeIfRequired(button => button.Text = value); }
    }
    #endregion

    #region Events
    public event EventHandler? OnCollectionsChanged;
    public event EventHandler? OnSelectedCollectionNameChanged;
    public event EventHandler? OnSelectedRequestNameChanged;
    public event EventHandler? OnRequestMethodChanged;
    public event EventHandler? OnRequestBodyTypeChanged;
    public event EventHandler? OnRequestSending;
    public event EventHandler? OnRequestCompleted;
    public event EventHandler? SendClicked;
    #endregion
}
