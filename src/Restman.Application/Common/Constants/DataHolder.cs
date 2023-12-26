namespace Restman.Application.Common.Constants;

public class DataHolder
{
    public const string JsonType = "application/json";
    public const string FormDataType = "multipart/form-data";

    public const string DefaultHttpClient = "DefaultHttpClient";
}

public class CollectionId
{
    public const string Reqres = "Reqres";

    public static List<string> All => new List<string>() 
    { 
        Reqres 
    };

}

public class AppConfigurationKey
{
    public static string SslClientCertificateFilePath(string collectionId) => $"{collectionId}:SSL:ClientCertificateFilePath";
    public static string SslClientCertificatePassword(string collectionId) => $"{collectionId}:SSL:ClientCertificatePassword";
    public static string SslServerCertificateHashString(string collectionId) => $"{collectionId}:SSL:ServerCertificateHashString";
}
