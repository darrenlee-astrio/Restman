using Restman.Application.Common.Equality;

namespace Restman.Application.Common.Models.AppData.Configuration;

public class HeaderConfiguration : KeyValueConfiguration<string, string>, IEqualityComparable
{
    public bool Enable { get; set; } = false;

    public override bool Equals(object? obj) => EqualityHelper.AreEqual(this, obj as HeaderConfiguration);

    public override int GetHashCode() => EqualityHelper.GetHashCode(this);
}
