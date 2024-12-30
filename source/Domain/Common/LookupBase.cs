using TMS.Domain.MarkarEntity;

namespace TMS.Domain.Common;

public abstract class LookupBase: BaseAuditableEntity ,IAuditable, ISoftDeletable
{
    public virtual DateTime? ValidFrom { get; set; }
    public virtual DateTime? ValidTo { get; set; }

    public virtual string? NameAr { get; set; }
    public virtual string? NameEn { get; set; }
    public virtual bool IsActive
    {
        get { return (ValidFrom == null || DateTime.Now >= ValidFrom) && (ValidTo == null || DateTime.Now <= ValidTo); }
    }
}
