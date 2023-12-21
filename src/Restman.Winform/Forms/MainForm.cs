using MediatR;
using Microsoft.Extensions.Logging;
using Restman.Application.Common.Extensions;
using Restman.Application.HttpRequests.ExecuteHttpRequest.Queries;
using Restman.Winform.Common.Extensions;
using Restman.Winform.Common.Helpers;
using Restman.Winform.Common.UiExtensions;
using System.Text;

namespace Restman.Winform
{
    public partial class MainForm : Form
    {
        private readonly ILogger<MainForm> _logger;
        private readonly LogForm _logForm;
        private readonly IMediator _mediator;
        private CancellationTokenSource? _httpRequestCancellationTokenSource;

        public MainForm(
            ILogger<MainForm> logger,
            LogForm logForm,
            IMediator mediator)
        {
            InitializeComponent();
            Init();
            _logger = logger;
            _logForm = logForm;
            _mediator = mediator;

            _logForm.Show();
        }

        private void Init()
        {
            httpMethodsComboBox.SelectedIndexChanged += HttpMethodsComboBox_SelectedIndexChanged;

            urlTextBox.Text = "https://reqres.in/api/users";

            httpMethodsComboBox.Initialize(HttpMethodExtensions.GetAllHttpMethods());
            requestQueryParamsDataGridView.Initialize(0.1, 0.45, 0.45);
            requestHeadersDataGridView.Initialize(0.1, 0.45, 0.45);
            responseHeadersDataGridView.Initialize(0.3, 0.7);

        }

        private void HttpMethodsComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (httpMethodsComboBox.Text == HttpMethod.Get.ToString())
            {
                noRequestBodyRadioButton.Checked = true;
                jsonRequestBodyRadioButton.Checked = false;
                jsonRequestBodyRadioButton.Enabled = false;
                formDataRequestBodyRadioButton.Checked = false;
                formDataRequestBodyRadioButton.Enabled = false;
            }
            else
            {
                jsonRequestBodyRadioButton.Enabled = true;
                formDataRequestBodyRadioButton.Enabled = true;
            }
        }

        private ExecuteHttpRequestQuery BuildHttpRequestQuery()
        {
            var queryParams = requestQueryParamsDataGridView.GetDictionary(onlyEnabledRows: true);
            var headers = requestHeadersDataGridView.GetDictionary(onlyEnabledRows: true);
            var urlWithQuery = $"{urlTextBox.Text}{QueryStringHelper.Generate(queryParams)}";

            return new ExecuteHttpRequestQuery(
                url: urlWithQuery,
                method: httpMethodsComboBox.Text,
                headers: headers,
                content: jsonRequestBodyRadioButton.Checked ? new StringContent(requestBodyJsonTextBox.Text, Encoding.UTF8, "application/json") : null
            );
        }

        private void CancelHttpRequest()
        {
            _httpRequestCancellationTokenSource?.Cancel();
            CleanupAfterHttpRequest();
        }
        private void CleanupAfterHttpRequest()
        {
            _httpRequestCancellationTokenSource?.Dispose();
            _httpRequestCancellationTokenSource = null;
            sendHttpRequestButton.Text = "Send";
        }

        private async void sendHttpRequestButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_httpRequestCancellationTokenSource is not null)
                {
                    CancelHttpRequest();
                    return;
                }

                sendHttpRequestButton.Text = "Cancel";
                _httpRequestCancellationTokenSource = new CancellationTokenSource();

                var request = BuildHttpRequestQuery();
                var result = await _mediator.Send(request, _httpRequestCancellationTokenSource.Token);

                if (!result.IsError)
                {
                    HandleHttpResponse(result.Value);
                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                CleanupAfterHttpRequest();
            }
        }

        private void HandleHttpResponse(ExecuteHttpRequestQueryResponse response)
        {
            httpResponseResultLabel.Text = new StringBuilder($"{(int)response.StatusCode} {response.StatusCode}")
                .Append("  |  ")
                .Append($"{response.ElapsedTime.TotalMilliseconds.ToString("#.##")} ms")
                .ToString();

            responseHeadersDataGridView.Rows.Clear();
            foreach (var kvp in response.Headers)
            {
                responseHeadersDataGridView.Rows.Add(kvp.Key, string.Join(";", kvp.Value));
            }
            httpResponseTextBox.Text = JsonHelper.PrettifyJson(response.Content);
        }

        private void RequestBodyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                if (radioButton == noRequestBodyRadioButton)
                {
                    requestBodyTabControl.SelectedIndex = 0;
                }
                else if (radioButton == jsonRequestBodyRadioButton)
                {
                    requestBodyTabControl.SelectedIndex = 1;
                }
                else if (radioButton == formDataRequestBodyRadioButton)
                {
                    requestBodyTabControl.SelectedIndex = 2;
                }
            }
        }
    }
}
