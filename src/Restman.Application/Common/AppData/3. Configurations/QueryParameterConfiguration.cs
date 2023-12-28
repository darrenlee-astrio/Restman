using Restman.Application.Common.Equality;

namespace Restman.Application.Common.Models.AppData.Configuration;

public class QueryParameterConfiguration : KeyValueConfiguration<string, string>, IEqualityComparable
{
    public bool Enable { get; set; } = false;

    public override bool Equals(object? obj) => EqualityHelper.AreEqual(this, obj as QueryParameterConfiguration);
    public override int GetHashCode() => EqualityHelper.GetHashCode(this);
}
