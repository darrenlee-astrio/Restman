using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restman.Application.Common.Constants;
using Restman.Application.Common.Formatters;
using Restman.Application.Common.Helpers;
using Restman.Application.HttpRequests.ExecuteHttpRequest.Queries;
using Restman.Winform.Common.Extensions;
using Restman.Winform.Views;
using Restman.Winform.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        _mainView.SendClicked += SendHttpRequest;
    }

    private async void SendHttpRequest(object? sender, EventArgs e)
    {
        try
        {
            if (_httpRequestCancellationTokenSource is not null)
            {
                _httpRequestCancellationTokenSource?.Cancel();
                HttpRequestCompleted();
                return;
            }

            IsSendingHttpRequest = true;
            _httpRequestCancellationTokenSource = new CancellationTokenSource();

            var result = await _mediator.Send(BuildHttpRequestQuery(), _httpRequestCancellationTokenSource.Token);

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
            _logger.LogError(ex, ex.Message);
        }
        finally
        {
            HttpRequestCompleted();
        }
    }

    private ExecuteHttpRequestQuery BuildHttpRequestQuery()
    {
        var queryParams = _mainView.RequestQueryParameters.GetDictionary(onlyEnabledRows: true);
        _mainView.Url = $"{_mainView.Url}{QueryStringHelper.Generate(queryParams)}";

        StringContent? content = null;
        if (_mainView.HasJsonBody && !string.IsNullOrEmpty(_mainView.RequestBodyJson))
        {
            content = new StringContent(_mainView.RequestBodyJson!, Encoding.UTF8, DataHolder.JsonType);
        }

        return new ExecuteHttpRequestQuery(
            url: _mainView.Url,
            method: _mainView.Method,
            headers: _mainView.RequestHeaders.GetDictionary(onlyEnabledRows: true),
            content: content
        );
    }
    private void HttpRequestCompleted()
    {
        _httpRequestCancellationTokenSource?.Dispose();
        _httpRequestCancellationTokenSource = null;
        IsSendingHttpRequest = false;
    }
    private void DisplayHttpResponse(ExecuteHttpRequestQueryResponse response)
    {
        _mainView.Result = new StringBuilder()
            .Append(StringFormatter.Format(response.StatusCode))
            .Append("  |  ")
            .Append(StringFormatter.Format(response.ElapsedTime))
            .ToString();
        _mainView.ResponseHeaders = response.Headers.ToKeyValueTwin();
        _mainView.ResponseBodyJson = JsonHelper.PrettifyJson(response.Content);
    }

    private bool _isSendingHttpRequest = false;
    public bool IsSendingHttpRequest
    {
        get { return _isSendingHttpRequest; }
        set
        {
            _isSendingHttpRequest = value;
            _mainView.SendHttpRequestButtonText = IsSendingHttpRequest ? "Cancel" : "Send";
        }
    }
}