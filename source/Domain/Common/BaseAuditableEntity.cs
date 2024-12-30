using TMS.Domain.Common;
using TMS.Domain.MarkarEntity;

namespace TMS.Domain;

public abstract class BaseAuditableEntity : BaseEntity , IAuditable , ISoftDeletable
{
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public string? Code { get; set; }

}
