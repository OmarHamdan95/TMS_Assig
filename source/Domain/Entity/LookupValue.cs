using System.ComponentModel.DataAnnotations;
using TMS.Domain.Common;

namespace TMS.Domain;

public class LookupValue : LookupBase
{
    public virtual Lookup? Lookup { get; set; }
    public virtual LookupValue? Parent { get; set; }
    public long? ParentId { get; set; }
    public long? Order { get; set; }
    public virtual bool IsSystem { get; set; }
    public string? Color { get; set; }
    public long? LookupId { get; set; }

    public LookupValue()
    {
    }

    public LookupValue(long id) => Id = id;

    public LookupValue(string code, long? order, string? color, string? nameAr, string? nameEn, long? parentId, long? lookupId)
    {
        Code = code;
        Order = order;
        Color = color;
        NameAr = nameAr;
        NameEn = nameEn;
        ParentId = parentId;
        LookupId = lookupId;
    }

    public void UpdateLookupValue(string? nameAr, string? nameEn)
    {
        NameAr = nameAr;
        NameEn = nameEn;
    }
}
