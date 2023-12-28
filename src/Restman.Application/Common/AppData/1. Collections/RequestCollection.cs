using Restman.Application.Common.Equality;
using Restman.Application.Common.Models.AppData.Request;

namespace Restman.Application.Common.Models.AppData.Collections;

public class RequestCollection : IEqualityComparable
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<RequestItem> Requests { get; set; } = new();
    public override bool Equals(object? obj) => EqualityHelper.AreEqual(this, obj as RequestCollection);
    public override int GetHashCode() => EqualityHelper.GetHashCode(this);
}
