namespace AjKpi.Domain;

public class Request : BaseAuditableEntity, IAggregateRoot , IWorkfklow
{
    public List<string?> CompositeKeys { get; set; }
    public List<string?> GlobalCompositeKeys { get; set; }
    public long? ExternalId { get; set; }
    public string? Number { get; set; }
    public string? Note { get; set; }
    public string? Data { get; set; }
    public string? AuthorType { get; set; }
    public string? AuthorId { get; set; }
    public long? StatusId { get; set; }
    public string? CurrentStatusDescriptionAr { get; set; }
    public string? CurrentStatusDescriptionEn { get; set; }
    public RequestStatus? Status { get; set; }

    public string? InitDepartmentCode { get; set; }
    public string? TargetDepartmentCode { get; set; }
    public string? TargetRoleCode { get; set; }

    public long? TypeId { get; set; }
    public RequestType? Type { get; set; }
    public List<WfTransaction> WfTransactions { get; set; }


    public Request(string data , long? statusId , long? typeId , string? number , List<string?> compositeKeys , List<string?> globalCompositeKeys,
        string? authorId , string? authorType , long? externalId , string? initDepartmentCode ,string? targetDepartmentCode ,string? targetRoleCode)
    {
        Data = data;
        StatusId = statusId;
        TypeId = typeId;
        Number = number;
        CompositeKeys = compositeKeys;
        GlobalCompositeKeys = globalCompositeKeys;
        AuthorId = authorId;
        AuthorType = authorId;
        ExternalId = externalId;
        InitDepartmentCode = initDepartmentCode;
        TargetDepartmentCode = targetDepartmentCode;
        TargetRoleCode = targetRoleCode;
    }
}
