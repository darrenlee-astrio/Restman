namespace Restman.Application.Common.Models;

public class RequestConfiguration
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string EndUrl { get; set; } = null!;
    public List<HeaderConfiguration> Headers { get; set; } = null!;
    public string? JsonContent { get; set; }
}
