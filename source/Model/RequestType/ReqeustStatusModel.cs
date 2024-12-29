namespace AjKpi.Model;

public class ReqeustStatusModel
{
    public long? Id { get; set; }
    public string? Code { get; set; }
    public string? ActionNameAr { get; set; }
    public string? ActionNameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? Color { get; set; }
    public string? CssClass { get; set; }
    public string? Icon { get; set; }
}


public class ReqeustStatusResultModel
{
    public string? Code { get; set; }
    public string? ActionNameAr { get; set; }
    public string? ActionNameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? Color { get; set; }
    public string? CssClass { get; set; }
    public string? Icon { get; set; }
    public List<string?> Roles { get; set; }

    public List<string?> NextStatusCodes { get; set; }

    public List<string?> PreviousStatusCodes { get; set; }
}
