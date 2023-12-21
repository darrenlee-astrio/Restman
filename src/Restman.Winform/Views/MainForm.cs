using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restman.Application.Common.Extensions;
using Restman.Application.Common.Helpers;
using Restman.Application.HttpRequests.ExecuteHttpRequest.Queries;
using Restman.Winform.Common.Extensions;
using Restman.Winform.Common.Models;
using Restman.Winform.Common.UiExtensions;
using Restman.Winform.Presenters;
using Restman.Winform.Views.Interfaces;
using System.Text;

namespace Restman.Winform.Views;

public partial class MainForm : Form, IMainView
{
    private readonly LogForm _logForm;
    private MainPresenter _presenter;

    public MainForm(ILogger<MainPresenter> logger,
        LogForm logForm,
        IMediator mediator)
    {
        InitializeComponent();
        Init();

        _logForm = logForm;
        _logForm.Show();

        _presenter = new MainPresenter(this, mediator, logger);
    }

    private void Init()
    {
        #region Events Initialisation
        sendHttpRequestButton.Click += (sender, e) => SendClicked?.Invoke(this, EventArgs.Empty);

        urlTextBox.TextChanged += (sender, e) => { Url = urlTextBox.Text; };
        requestBodyJsonTextBox.TextChanged += (sender, e) => { RequestBodyJson = requestBodyJsonTextBox.Text; };
        httpMethodsComboBox.SelectedIndexChanged += (sender, e) => { Method = httpMethodsComboBox.Text; };
        noRequestBodyRadioButton.CheckedChanged += (sender, e) => { requestBodyTabControl.SelectedIndex = 0; };
        jsonRequestBodyRadioButton.CheckedChanged += (sender, e) => { requestBodyTabControl.SelectedIndex = 1; };
        formDataRequestBodyRadioButton.CheckedChanged += (sender, e) => { requestBodyTabControl.SelectedIndex = 2; };
        #endregion

        Url = "https://reqres.in/api/users";

        httpMethodsComboBox.Initialize(HttpMethodExtensions.GetAllHttpMethods());
        requestQueryParamsDataGridView.Initialize(0.1, 0.45, 0.45);
        requestHeadersDataGridView.Initialize(0.1, 0.45, 0.45);
        responseHeadersDataGridView.Initialize(0.3, 0.7);
    }

    #region Properties
    public string Method
    {
        get => httpMethodsComboBox.Text;
        set
        {
            httpMethodsComboBox.SelectedIndex = httpMethodsComboBox.FindString(value);

            if (value == HttpMethod.Get.ToString())
            {
                HasNoBody = true;
                HasJsonBody = false;
                HasFormData = false;
                jsonRequestBodyRadioButton.Enabled = false;
                formDataRequestBodyRadioButton.Enabled = false;
            }
            else
            {
                jsonRequestBodyRadioButton.Enabled = true;
                formDataRequestBodyRadioButton.Enabled = true;
            }
        }
    }

    public string Url
    {
        get { return urlTextBox.Text; }
        set { urlTextBox.Text = value; }
    }

    public string? Content
    {
        get { return requestBodyJsonTextBox.Text; }
        set { requestBodyJsonTextBox.Text = value; }
    }

    public List<KeyValueTwinWithEnable> RequestQueryParameters
    {
        get { return requestQueryParamsDataGridView.GetData<KeyValueTwinWithEnable>(); }
        set
        {
            requestQueryParamsDataGridView.Rows.Clear();
            foreach (KeyValueTwinWithEnable row in value)
            {
                requestQueryParamsDataGridView.Rows.Add(row.Enable, row.Key, row.Value);
            }
        }
    }

    public List<KeyValueTwinWithEnable> RequestHeaders
    {
        get { return requestHeadersDataGridView.GetData<KeyValueTwinWithEnable>(); }
        set
        {
            requestHeadersDataGridView.Rows.Clear();
            foreach (KeyValueTwinWithEnable row in value)
            {
                requestHeadersDataGridView.Rows.Add(row.Enable, row.Key, row.Value);
            }
        }
    }
    
    public bool HasNoBody
    {
        get { return noRequestBodyRadioButton.Checked; }
        set
        {
            noRequestBodyRadioButton.Checked = value;

            if (value)
            {
                HasJsonBody = false;
                HasFormData = false;
            }
        }
    }

    public bool HasJsonBody
    {
        get { return jsonRequestBodyRadioButton.Checked; }
        set
        {
            jsonRequestBodyRadioButton.Checked = value;

            if (value)
            {
                HasNoBody = false;
                HasFormData = false;
            }
        }
    }

    public bool HasFormData
    {
        get { return formDataRequestBodyRadioButton.Checked; }
        set
        {
            formDataRequestBodyRadioButton.Checked = value;

            if (value)
            {
                HasNoBody = false;
                HasJsonBody = false;
            }
        }
    }

    public string? RequestBodyJson
    {
        get { return requestBodyJsonTextBox.Text; }
        set { requestBodyJsonTextBox.Text = value; }
    }

    public string Result
    {
        get { return httpResponseResultLabel.Text; }
        set { httpResponseResultLabel.Text = value; }
    }

    public string? ResponseBodyJson
    {
        get { return httpResponseTextBox.Text; }
        set { httpResponseTextBox.Text = value; }
    }

    public List<KeyValueTwin> ResponseHeaders
    {
        get { return responseHeadersDataGridView.GetData<KeyValueTwin>(); }
        set
        {
            responseHeadersDataGridView.Rows.Clear();
            foreach (KeyValueTwin row in value)
            {
                responseHeadersDataGridView.Rows.Add(row.Key, row.Value);
            }
        }
    }

    public string SendHttpRequestButtonText
    {
        get { return sendHttpRequestButton.Text; }
        set { sendHttpRequestButton.Text = value; }
    }
    #endregion

    #region Events

    public event EventHandler? SendClicked;

    #endregion
}
