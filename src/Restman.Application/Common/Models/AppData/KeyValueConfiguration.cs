namespace Restman.Application.Common.Models.AppData;

public class KeyValueConfiguration
{
    public bool Enable { get; set; } = false;
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}