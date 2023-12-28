using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restman.Application.Common.Constants;
using Restman.Application.Common.Extensions;
using Restman.Application.Common.Formatters;
using Restman.Application.Common.Helpers;
using Restman.Application.Common.Models.AppData.Configuration;
using Restman.Application.Http;
using Restman.Winform.Common.Extensions;
using Restman.Winform.Views.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace Restman.Winform.Presenters;

public class MainPresenter
{
    private readonly IMainView _mainView;
    private readonly ISender _mediator;
    private readonly ILogger _logger;
    private CancellationTokenSource? _httpRequestCancellationTokenSource;

    public MainPresenter(IMainView mainView, ISender mediator, ILogger logger)
    {
        _mainView = mainView;
        _mediator = mediator;
        _logger = logger;

        _mainView.OnCollectionsChanged += OnCollectionsChanged;
        _mainView.OnSelectedCollectionNameChanged += OnSelectedCollectionNameChanged;
        _mainView.OnSelectedRequestNameChanged += OnSelectedRequestNameChanged;
        _mainView.OnRequestMethodChanged += OnRequestMethodChanged;
        _mainView.OnRequestBodyTypeChanged += OnRequestBodyTypeChanged;
        _mainView.OnRequestQueryParameterChanged += OnRequestQueryParameterChanged;
        _mainView.OnHeaderConfigurationChanged += OnHeaderConfigurationChanged;
        _mainView.OnRequestSending += OnRequestSending;
        _mainView.OnRequestCompleted += OnRequestCompleted;
        _mainView.SendClicked += SendHttpRequest;
    }

    public void Cleanup()
    {
        if (_mainView.IsRequestSending)
        {
            _httpRequestCancellationTokenSource?.Cancel();
            _mainView.IsRequestCompleted = true;
        }
    }

    #region Ui Changed Events
    private void OnCollectionsChanged(object? sender, EventArgs e)
    {
        _mainView.CollectionNames = _mainView.Collections.Select(x => x.Name).ToList();
        _mainView.SelectedCollection = _mainView.Collections.First();
        _mainView.SelectedCollectionName = _mainView.SelectedCollection.Name;
        _mainView.SelectedCollectionDescription = _mainView.SelectedCollection.Description;
    }
    private void OnSelectedCollectionNameChanged(object? sender, EventArgs e)
    {
        _mainView.Requests = _mainView.SelectedCollection.Requests;
        _mainView.RequestNames = _mainView.Requests.Select(x => x.Name).ToList();
        _mainView.SelectedRequest = _mainView.Requests.First();
        _mainView.SelectedRequestName = _mainView.SelectedRequest.Name;
    }
    private void OnSelectedRequestNameChanged(object? sender, EventArgs e)
    {
        _mainView.SelectedRequest = _mainView.Requests.Where(x => x.Name == _mainView.SelectedRequestName).First();
        _mainView.Method = _mainView.SelectedRequest.Method;
        _mainView.QueryParameterConfigurations = _mainView.SelectedRequest.QueryParameterConfigurations;
        _mainView.Url = GenerateRequestUrl();
        _mainView.SelectedRequestDescription = _mainView.SelectedRequest.Description;
        _mainView.HeaderConfigurations = _mainView.SelectedRequest.HeaderConfigurations;

        if (!string.IsNullOrEmpty(_mainView.SelectedRequest.JsonConfiguration))
        {
            _mainView.HasJsonBody = true;
            _mainView.JsonConfiguration = _mainView.SelectedRequest.JsonConfiguration;
        }
        else
        {
            _mainView.HasNoBody = true;
            _mainView.JsonConfiguration = string.Empty;
        }

        if (_mainView.SelectedRequest.FormDataConfiguration.Count > 0)
        {
            _mainView.HasFormData = true;
            _mainView.FormDataConfigurations = _mainView.SelectedRequest.FormDataConfiguration;
        }

        _mainView.SavedQueryParameterConfigurations = _mainView.QueryParameterConfigurations;
        _mainView.SavedHeaderConfigurations = _mainView.HeaderConfigurations;
        _mainView.SavedJsonConfiguration = _mainView.JsonConfiguration;
        _mainView.SavedFormDataConfigurations = _mainView.FormDataConfigurations;
    }
    private void OnRequestBodyTypeChanged(object? sender, EventArgs e)
    {
        if (_mainView.HasNoBody)
        {
            _mainView.HasJsonBody = false;
            _mainView.HasFormData = false;
        }
        else if (_mainView.HasJsonBody)
        {
            _mainView.HasNoBody = false;
            _mainView.HasFormData = false;
        }
        else if (_mainView.HasFormData)
        {
            _mainView.HasNoBody = false;
            _mainView.HasFormData = false;
        }
    }
    private void OnRequestMethodChanged(object? sender, EventArgs e)
    {
        switch (_mainView.Method)
        {
            case "GET":
                _mainView.HasNoBody = true;
                break;
        }
    }
    private void OnRequestQueryParameterChanged(object? sender, EventArgs e)
    {
        _mainView.SelectedRequest.QueryParameterConfigurations = _mainView.QueryParameterConfigurations;
        _mainView.Url = GenerateRequestUrl();
    }
    private void OnHeaderConfigurationChanged(object? sender, EventArgs e)
    {
        _mainView.SelectedRequest.HeaderConfigurations = _mainView.HeaderConfigurations;
    }

    private void OnRequestSending(object? sender, EventArgs e)
    {
        if (_mainView.IsRequestSending)
        {
            _mainView.IsRequestCompleted = false;
            _mainView.SendHttpRequestButtonText = "Cancel";
        }
    }
    private void OnRequestCompleted(object? sender, EventArgs e)
    {
        if (_mainView.IsRequestCompleted)
        {
            _mainView.IsRequestSending = false;
            _mainView.SendHttpRequestButtonText = "Send";
            _httpRequestCancellationTokenSource?.Dispose();
            _httpRequestCancellationTokenSource = null;
            _mainView.IsRequestSending = false;
        }
    }
    #endregion

    #region Action Events
    private async void SendHttpRequest(object? sender, EventArgs e)
    {
        try
        {
            if (_httpRequestCancellationTokenSource is not null)
            {
                _httpRequestCancellationTokenSource.Cancel();
                _mainView.IsRequestCompleted = true;
                return;
            }

            _mainView.IsRequestSending = true;
            _httpRequestCancellationTokenSource = new CancellationTokenSource();

            ErrorOr<CommonHttpResponse> result = await _mediator.Send(CreateCommonHttpCommand(), _httpRequestCancellationTokenSource.Token);

            if (result.IsError)
            {
                var error = result.Errors.Select(x => new { x.Code, x.Description });
                _logger.LogWarning($"Unable to process the request.\n {JsonConvert.SerializeObject(error, Formatting.Indented)}");
                return;
            }

            DisplayHttpResponse(result.Value);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Request cancelled successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while sending HTTP request.");
        }
        finally
        {
            _mainView.IsRequestCompleted = true;
        }
    }
    #endregion

    private CommonHttpCommand CreateCommonHttpCommand()
    {
        _mainView.Url = GenerateRequestUrl();

        HttpContent? content = null;
        content = _mainView.HasJsonBody ? new StringContent(_mainView.JsonConfiguration!) : null;
        content = _mainView.HasFormData ? CreateMultipartFormDataContent(_mainView.FormDataConfigurations) : null;

        return new CommonHttpCommand(
            collectionId: _mainView.SelectedCollection.Id,
            url: _mainView.Url,
            method: _mainView.Method,
            headers: _mainView.HeaderConfigurations.GetDictionary(omitDisabled: true),
            content: content
        );
    }

    private MultipartFormDataContent CreateMultipartFormDataContent(List<FormDataConfiguration> items)
    {
        var formData = new MultipartFormDataContent();

        foreach (var item in items)
        {
            if (item.Type == "file")
            {
                if (File.Exists(item.Value) is false)
                {
                    throw new FileNotFoundException("The specified file could not be found.", item.Value);
                }

                var fileExtension = Path.GetExtension(item.Value);

                using (var fileStream = File.OpenRead(item.Value))
                {
                    var fileContent = new StreamContent(fileStream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(GetContentType(fileExtension));
                    formData.Add(fileContent, item.Key, $"{item.Key}{fileExtension}");
                }
            }
            else if (item.Type == "text")
            {
                formData.Add(new StringContent(item.Value), item.Key);
            }
        }
        return formData;
    }

    private string GetContentType(string fileExtension)
    {
        if (Mappings.ContentType.TryGetValue(fileExtension, out var contentType))
        {
            return contentType;
        }

        throw new NotSupportedException($"Unable to generate content type for {fileExtension}.");
    }

    private string GenerateRequestUrl()
    {
        var queryParams = _mainView.QueryParameterConfigurations.GetDictionary(omitDisabled: true);
        return $"{_mainView.SelectedRequestFullUrl}{QueryStringHelper.Generate(queryParams)}";
    }
    private void DisplayHttpResponse(CommonHttpResponse response)
    {
        _mainView.Result = new StringBuilder()
            .Append(StringFormatter.Format(response.StatusCode))
            .Append("  |  ")
            .Append(StringFormatter.Format(response.ElapsedTime))
            .ToString();
        _mainView.ResponseHeaders = response.Headers.ToKeyValueConfigurations();
        _mainView.JsonResponse = JsonHelper.PrettifyJson(response.Content);
    }
}