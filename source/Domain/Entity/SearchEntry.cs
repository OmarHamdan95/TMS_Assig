namespace AjKpi.Domain;

public class SearchEntry :  IWorkfklow
{
    public string? Name { get; set; }

    public string? Path { get; set; }

    public string? Type { get; set; }

    public string? RequestTypeId { get; set; }

    public RequestType? RequestType { get; set; }

    public SearchEntry()
    {

    }

    public string? Code { get; set; }
}
