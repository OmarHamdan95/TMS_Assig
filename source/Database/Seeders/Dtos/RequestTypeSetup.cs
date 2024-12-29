namespace AjKpi.Database.Seeders.Dtos;

public class RequestTypeSetup
{
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }

    public string? Code { get; set; }

    public string? RequestNumberTemplate { get; set; }

    public string? CompositeKeyTemplate { get; set; }

    public bool PreventConcurrentRequests { get; set; }

    public string? GlobalCompositeKeyTemplate { get; set; }

    public List<string?> ConcurrencyPreventedTypeCodes { get; set; }

    public string? EventQueueName { get; set; }

    public int? MaxAllowedRequests { get; set; }

    public List<SearchEntry> SearchEntries { get; set; }

    public List<RequestTypeStatusSetup> Statuses { get; set; }
}

public class SearchEntryDto
{
    public string? Name { get; set; }

    public string? Path { get; set; }

    public string? Type { get; set; }
}


public class RequestTypeStatusSetup
{
    public string? Code { get; set; }

    public string? ActionNameAr { get; set; }
    public string? ActionNameEn { get; set; }

    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }

    public bool IsStartingState { get; set; }

    public bool IsEndState { get; set; }

    public bool IsEditable { get; set; }

    public bool IsAction { get; set; }

    public bool IsDeletable { get; set; }

    public List<string?> Roles { get; set; }

    public List<string?> NextStatusCodes { get; set; }

    public List<string?> PreviousStatusCodes { get; set; }

    public string? CssClass { get; set; }

    public string? Icon { get; set; }

    public string? Color { get; set; }
    public string? DepartmentCode { get; set; }
}
