using Restman.Application.Common.Equality;

namespace Restman.Application.Common.Models.AppData.Configuration;

public abstract class KeyValueConfiguration<T, U>
{
    public required T Key { get; set; }
    public required U Value { get; set; }
}

public class KeyValueConfiguration : IEqualityComparable
{
    public required string Key { get; set; }
    public required string Value { get; set; }

    public override bool Equals(object? obj) => EqualityHelper.AreEqual(this, obj as KeyValueConfiguration);
    public override int GetHashCode() => EqualityHelper.GetHashCode(this);
}
