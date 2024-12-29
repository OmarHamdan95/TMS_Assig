namespace AjKpi.Domain;

public class WfTransaction :BaseAuditableEntity , IWorkfklow
{
    public Request? Request { get; set; }
    public long? RequestId { get; set; }
    public string? Comment { get; set; }
    public string? Action { get; set; }

    public string? OldStatusCode { get; set; }
    public string? OldStatusDescriptionAr { get; set; }
    public string? OldStatusDescriptionEn { get; set; }
    public string? NewStatusCode { get; set; }
    public string? NewStatusDescriptionAr { get; set; }
    public string? NewStatusDescriptionEn { get; set; }
    public string? DepartmentCode { get; set; }
    public string? RoleCode { get; set; }

    public WfTransaction(long? requestId, string? comment, string action , string? oldStatusCode , string? oldStatusDescriptionAr , string? oldStatusDescriptionEn ,
    string? newStatusCode , string? newStatusDescriptionAr , string? newStatusDescriptionEn ,string? departmentCode , string? roleCode)
    {
        RequestId = requestId;
        Comment = comment;
        Action = action;
        OldStatusCode = oldStatusCode;
        OldStatusDescriptionAr = oldStatusDescriptionAr;
        OldStatusDescriptionEn = oldStatusDescriptionEn;
        NewStatusCode = newStatusCode;
        NewStatusDescriptionAr = newStatusDescriptionAr;
        NewStatusDescriptionEn = newStatusDescriptionEn;
        DepartmentCode = departmentCode;
        RoleCode = roleCode;
    }
}
