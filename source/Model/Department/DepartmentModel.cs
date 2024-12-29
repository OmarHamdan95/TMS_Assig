namespace AjKpi.Model;

public sealed record DepartmentModel
{
    public long Id { get; init; }
    public string? NameAr { get; init; }
    public string? NameEn { get; init; }
    public string? Code { get; init; }
}

