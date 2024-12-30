namespace TMS.Domain.MarkarEntity;

public interface IAuditable
{
    long Id { get; set; }
    string? CreatedBy { get; set; }
    DateTime? CreatedDate { get; set; }
    string? ModifiedBy { get; set; }
    DateTime? ModifiedDate { get; set; }
}
