
using Restman.Winform.Common.Extensions;
using Restman.Winform.Common.Helpers;
using Restman.Winform.Common.Models;
using Restman.Winform.Common.UiExtensions;
using System.Text;
using System.Windows.Forms;

namespace Restman.Winform
{
    public partial class MainForm : Form
    {
        private LogForm _logForm = new LogForm();
        public MainForm()
        {
            InitializeComponent();
            Init();

            //TODO: Add logging
            _logForm.Show();
            _logForm.LogInformation("Testing");
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

        private async void sendHttpRequestButton_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                var url = urlTextBox.Text;
                var method = HttpMethod.Parse(httpMethodsComboBox.Text);

                var enabledRequestQueryParams = requestQueryParamsDataGridView
                                            .GetData<KeyValuePairRow>()
                                            .Where(x => x.Enable == true)
                                            .ToList();

                var enabledRequestHeaders = requestHeadersDataGridView
                                        .GetData<KeyValuePairRow>()
                                        .Where(x => x.Enable == true)
                                        .ToList();

                var urlWithQuery = $"{url}{GenerateQueryString(enabledRequestQueryParams)}";
                urlTextBox.Text = urlWithQuery;

                using (var request = new HttpRequestMessage(method, urlWithQuery))
                {
                    foreach (var kvp in enabledRequestHeaders)
                    {
                        request.Headers.Add(kvp.Key, kvp.Value);
                    }

                    if (jsonRequestBodyRadioButton.Checked)
                    {
                        request.Content = new StringContent(requestBodyJsonTextBox.Text, Encoding.UTF8, "application/json");
                    }

                    (HttpResponseMessage response, TimeSpan elapsedTime) = await httpClient.SendTimedAsync(request);

                    var sb = new StringBuilder();
                    sb.Append($"{(int)response.StatusCode} {response.StatusCode}");
                    sb.Append("  |  ");
                    sb.Append($"{elapsedTime.TotalMilliseconds.ToString("#.##")} ms");
                    httpResponseResultLabel.Text = sb.ToString();

                    responseHeadersDataGridView.Rows.Clear();
                    foreach (var kvp in response.Headers)
                    {
                        responseHeadersDataGridView.Rows.Add(kvp.Key, string.Join(";", kvp.Value));
                    }

                    string content = await response.Content.ReadAsStringAsync();
                    httpResponseTextBox.Text = JsonHelper.PrettifyJson(content);
                }
            }
        }

        private string GenerateQueryString(List<KeyValuePairRow> kvpRows)
        {
            if (kvpRows.Count == 0)
            {
                return string.Empty;
            }

            string queryString = string.Join("&",
                kvpRows.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

            return "?" + queryString;
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
