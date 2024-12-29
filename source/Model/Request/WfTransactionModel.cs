namespace AjKpi.Model;

public class WfTransactionModel
{
    public long? Id { get; set; }
    public long? RequestId { get; set; }
    public string? Comment { get; set; }
    public string? Action { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? OldStatusCode { get; set; }
    public string? OldStatusDescriptionAr { get; set; }
    public string? OldStatusDescriptionEn { get; set; }
    public string? NewStatusCode { get; set; }
    public string? NewStatusDescriptionAr { get; set; }
    public string? NewStatusDescriptionEn { get; set; }
    public string? DepartmentCode { get; set; }
    public string? RoleCode { get; set; }
}
