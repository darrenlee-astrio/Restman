namespace Restman.Application.Common.Models;

public class RequestCollection
{
    public string Name { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<HeaderItem> DefaultHeaders { get; set; } = null!;
    public List<RequestItem> Requests { get; set; } = new();
}
