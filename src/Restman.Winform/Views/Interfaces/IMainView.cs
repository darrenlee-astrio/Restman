using Restman.Application.Common.Models.AppData.Collections;
using Restman.Application.Common.Models.AppData.Configuration;
using Restman.Application.Common.Models.AppData.Request;

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
    string JsonConfiguration { get; set; }
    List<QueryParameterConfiguration> QueryParameterConfigurations { get; set; }
    List<HeaderConfiguration> HeaderConfigurations { get; set; }
    List<FormDataConfiguration> FormDataConfigurations { get; set; }

    string SavedJsonConfiguration { get; set; }
    List<QueryParameterConfiguration> SavedQueryParameterConfigurations { get; set; }
    List<HeaderConfiguration> SavedHeaderConfigurations { get; set; }
    List<FormDataConfiguration> SavedFormDataConfigurations { get; set; }

    bool HasNoBody { get; set; }
    bool HasJsonBody { get; set; }
    bool HasFormData { get; set; }

    string Result { get; set; }
    string? JsonResponse { get; set; }
    List<KeyValueConfiguration> ResponseHeaders { get; set; }

    bool IsRequestSending { get; set; }
    bool IsRequestCompleted { get; set; }
    string SendHttpRequestButtonText { get; set; }
    string SelectedCollectionDescription { get; set; }
    string SelectedRequestDescription { get; set; }
    bool HasUnsavedChanges { get; }

    event EventHandler OnCollectionsChanged;
    event EventHandler OnSelectedCollectionNameChanged;
    event EventHandler OnSelectedRequestNameChanged;
    event EventHandler OnRequestMethodChanged;
    event EventHandler OnRequestBodyTypeChanged;
    event EventHandler OnRequestQueryParameterChanged;
    event EventHandler OnHeaderConfigurationChanged;

    event EventHandler OnRequestSending;
    event EventHandler OnRequestCompleted;
    event EventHandler SendClicked;
}