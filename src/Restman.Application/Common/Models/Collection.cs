namespace Restman.Application.Common.Models;

public class Collection
{
    public string Name { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public List<HeaderConfiguration> DefaultHeaders { get; set; } = null!;
    public List<RequestConfiguration> Requests { get; set; } = new();
}
