namespace AjKpi.Domain;

public class RequestStatus : BaseEntity, IWorkfklow
{
    public string? Code { get; set; }
    public bool? IsDeleted { get; set; }
    public string? ActionNameAr { get; set; }
    public string? ActionNameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }

    public List<string?> Roles { get; set; }

    public List<string?> NextStatusCodes { get; set; }

    public List<string?> PreviousStatusCodes { get; set; }

    public bool? IsStartingState { get; set; }

    public bool? IsEditable { get; set; }

    public bool? IsDeletable { get; set; }

    public bool? IsEndState { get; set; }

    public bool? IsAction { get; set; }

    public string? Color { get; set; }

    public string? CssClass { get; set; }

    public string? Icon { get; set; }

    public long? RequestTypeId { get; set; }
    public RequestType RequestType { get; set; }

    public bool SelfAllowed { get; set; } = true;

    public string? DepartmentCode { get; set; }
}
