namespace AjKpi.Model;

public class RequestTypeModel
{
    public string? Code { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? RequestNumberTemplate { get; set; }
    public string? CompositeKeyTemplate { get; set; }
    public string? GlobalCompositeKeyTemplate { get; set; }
    public bool? PreventConcurrentRequests { get; set; }
    public List<string?> ConcurrencyPreventedTypeCodes { get; set; }
    public int? MaxAllowedRequests { get; set; }
    public string? EventQueueName { get; set; }
}


public class RequestTypeResultModel
{
    public string? Code { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public List<ReqeustStatusModel?> Statuses { get; set; }

}

public class RequestTypeGrid
{
    public string? Code { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
}
