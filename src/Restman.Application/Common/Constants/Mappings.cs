namespace Restman.Application.Common.Constants;

public class Mappings
{
    public static Dictionary<string, string> ContentType = new Dictionary<string, string>
        {
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".png", "image/png" },
            { ".gif", "image/gif" },
            { ".txt", "text/plain" },
            { ".pdf", "application/pdf" },
            { ".zip", "application/zip" }
        };
}
