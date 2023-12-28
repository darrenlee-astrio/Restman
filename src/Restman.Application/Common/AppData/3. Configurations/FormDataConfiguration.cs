using Restman.Application.Common.Equality;

namespace Restman.Application.Common.Models.AppData.Configuration;

public class FormDataConfiguration : KeyValueConfiguration<string, string>, IEqualityComparable
{
    public bool Enable { get; set; }
    public string Type { get; set; } = null!;

    public override bool Equals(object? obj) => EqualityHelper.AreEqual(this, obj as FormDataConfiguration);
    public override int GetHashCode() => EqualityHelper.GetHashCode(this);
}
