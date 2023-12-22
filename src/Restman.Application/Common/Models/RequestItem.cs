namespace Restman.Application.Common.Models;

public class RequestItem
{
    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public string Method { get; set; } = null!;
    public string EndUrl { get; set; } = null!;
    public List<HeaderItem> Headers { get; set; } = new();
    public string? JsonContent { get; set; }
}
