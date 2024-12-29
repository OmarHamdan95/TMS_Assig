namespace AjKpi.Domain;

public class RequestType : BaseEntity, IWorkfklow
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
    public virtual ICollection<RequestStatus> Statuses { get; set; }
    public virtual ICollection<SearchEntry> SearchEntries { get; set; }


}
