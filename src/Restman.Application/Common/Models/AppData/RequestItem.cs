namespace Restman.Application.Common.Models.AppData;

public class RequestItem
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Method { get; set; } = null!;
    public string EndUrl { get; set; } = null!;
    public List<KeyValueConfiguration> Headers { get; set; } = new();
    public List<KeyValueConfiguration> QueryParams { get; set; } = new();
    public string? JsonContent { get; set; }
}
