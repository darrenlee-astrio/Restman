using Restman.Application.Common.Models.AppData;
using Restman.Winform.Common.Models;

namespace Restman.Winform.Views.Interfaces;

public interface IMainView
{
    List<RequestCollection> Collections { get; set; }
    List<RequestItem> Requests { get; set; }
    RequestCollection SelectedCollection { get; set; }
    RequestItem SelectedRequest { get; set; }

    List<string> CollectionNames { get; set; }
    List<string> RequestNames { get; set; }
    string SelectedCollectionName { get; set; }
    string SelectedRequestName { get; set; }
    string SelectedRequestFullUrl { get; }

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

    bool IsRequestSending { get; set; }
    bool IsRequestCompleted { get; set; }
    string SendHttpRequestButtonText { get; set; }
    string SelectedCollectionDescription { get; set; }
    string SelectedRequestDescription { get; set; }

    event EventHandler OnCollectionsChanged;
    event EventHandler OnSelectedCollectionNameChanged;
    event EventHandler OnSelectedRequestNameChanged;
    event EventHandler OnRequestMethodChanged;
    event EventHandler OnRequestBodyTypeChanged;
    event EventHandler OnRequestQueryParameterChanged;

    event EventHandler OnRequestSending;
    event EventHandler OnRequestCompleted;
    event EventHandler SendClicked;


}