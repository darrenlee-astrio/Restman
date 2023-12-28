using Restman.Application.Common.Equality;
using Restman.Application.Common.Models.AppData.Configuration;

namespace Restman.Application.Common.Models.AppData.Request;

public class RequestItem : IEqualityComparable
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Method { get; set; } = null!;
    public string EndUrl { get; set; } = null!;
    public List<HeaderConfiguration> HeaderConfigurations { get; set; } = new();
    public List<QueryParameterConfiguration> QueryParameterConfigurations { get; set; } = new();
    public string? JsonConfiguration { get; set; }
    public List<FormDataConfiguration> FormDataConfiguration { get; set; } = new();

    public override bool Equals(object? obj) => EqualityHelper.AreEqual(this, obj as RequestItem);
    public override int GetHashCode() => EqualityHelper.GetHashCode(this);
}
