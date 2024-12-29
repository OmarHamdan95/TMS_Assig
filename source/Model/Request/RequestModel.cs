using Newtonsoft.Json.Linq;

namespace AjKpi.Model;

public class RequestModel
{
    public long? ExternalId { get; set; }
    public string? Data { get; set; }

    public string? Status { get; set; }
    public string? Type { get; set; }

    public string? AuthorId { get; set; }

    public string? AuthorType { get; set; }

    public string? InitDepartmentCode { get; set; }
    public string? TargetDepartmentCode { get; set; }
    public string? TargetRoleCode { get; set; }
}

public class RequestResultModel
{
    public long? Id { get; set; }
    public long? ExternalId { get; set; }

    public ReqeustStatusResultModel? Status { get; set; }
    public RequestTypeResultModel? Type { get; set; }

    public string? AuthorId { get; set; }

    public string? AuthorType { get; set; }
}

public class RequestGridModel
{
    public long? Id { get; set; }
    public long? ExternalId { get; set; }
    public long? StatusId { get; set; }
    public long? TypeId { get; set; }

    public ReqeustStatusResultModel? Status { get; set; }
    public RequestTypeGrid? Type { get; set; }
    public string? Data { get; set; }
    public string? Number { get; set; }
}

public class RequestResult
{
    public long? Id { get; set; }

    public string? Number { get; set; }

    public List<string?> CompositeKeys { get; set; }

    public List<string?> GlobalCompositeKeys { get; set; }

    public string? TypeCode { get; set; }
}
