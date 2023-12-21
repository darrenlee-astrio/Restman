using Restman.Winform.Common.Models;

namespace Restman.Winform.Views.Interfaces;

public interface IMainView
{
    string Method { get; set; }
    string Url { get; set; }
    string? RequestBodyJson { get; set; }
    List<KeyValueTwinWithEnable> RequestQueryParameters { get; set; }
    List<KeyValueTwinWithEnable> RequestHeaders { get; set; }

    bool HasNoBody { get; set; }
    bool HasJsonBody { get; set; }
    bool HasFormData { get; set; }

    string Result { get; set; }
    string? ResponseBodyJson { get; set; }
    List<KeyValueTwin> ResponseHeaders { get; set; }

    event EventHandler SendClicked;

    string SendHttpRequestButtonText { get; set; }
}