namespace Restman.Application.Common.Models.AppData;

public class RequestCollection
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<KeyValueConfiguration> DefaultHeaders { get; set; } = null!;
    public List<RequestItem> Requests { get; set; } = new();
}
