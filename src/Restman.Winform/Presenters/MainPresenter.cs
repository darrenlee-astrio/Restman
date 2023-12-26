using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restman.Application.Common.Formatters;
using Restman.Application.Common.Helpers;
using Restman.Application.Http;
using Restman.Winform.Common.Extensions;
using Restman.Winform.Views.Interfaces;
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
        _mainView.RequestQueryParameters = _mainView.SelectedRequest.QueryParams.ToKeyValueTwinsWithEnable();
        _mainView.Url = GenerateRequestUrl();
        _mainView.SelectedRequestDescription = _mainView.SelectedRequest.Description;

        var collectionDefaultHeaders = _mainView.SelectedCollection.DefaultHeaders.ToKeyValueTwinsWithEnable();
        var requestHeaders = _mainView.SelectedRequest.Headers.ToKeyValueTwinsWithEnable();
        _mainView.RequestHeaders = collectionDefaultHeaders.Combine(requestHeaders);

        if (!string.IsNullOrEmpty(_mainView.SelectedRequest.JsonContent))
        {
            _mainView.HasJsonBody = true;
            _mainView.RequestBodyJson = _mainView.SelectedRequest.JsonContent;
        }
        else
        {
            _mainView.HasNoBody = true;
            _mainView.RequestBodyJson = string.Empty;
        }
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
        _mainView.Url = GenerateRequestUrl();
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
        var queryParams = _mainView.RequestQueryParameters.GetDictionary(onlyEnabledRows: true);
        _mainView.Url = GenerateRequestUrl();

        HttpContent? content = null;
        content = _mainView.HasJsonBody ? new StringContent(_mainView.RequestBodyJson!) : null;
        //content = _mainView.HasFormData ? null : null;

        return new CommonHttpCommand(
            collectionId: _mainView.SelectedCollection.Id,
            url: _mainView.Url,
            method: _mainView.Method,
            headers: _mainView.RequestHeaders.GetDictionary(onlyEnabledRows: true),
            content: content
        );
    }

    private string GenerateRequestUrl()
    {
        var queryParams = _mainView.RequestQueryParameters.GetDictionary(onlyEnabledRows: true);
        return $"{_mainView.SelectedRequestFullUrl}{QueryStringHelper.Generate(queryParams)}";
    }
    private void DisplayHttpResponse(CommonHttpResponse response)
    {
        _mainView.Result = new StringBuilder()
            .Append(StringFormatter.Format(response.StatusCode))
            .Append("  |  ")
            .Append(StringFormatter.Format(response.ElapsedTime))
            .ToString();
        _mainView.ResponseHeaders = response.Headers.ToKeyValueTwin();
        _mainView.ResponseBodyJson = JsonHelper.PrettifyJson(response.Content);
    }

}