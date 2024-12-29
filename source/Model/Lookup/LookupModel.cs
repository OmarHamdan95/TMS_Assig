namespace AjKpi.Model;

public sealed record LookupModel
{
    public long Id { get; init; }
    public string? NameAr { get; init; }
    public string? NameEn { get; init; }
    public string? Code { get; init; }
    public LookupParentModel? Parent { get; init; }
    public long? Links { get; init; }
    public string? DataType { get; init; }
    public List<LookupValueModel>? LookupValues { get; init; }
}

public sealed record LookupParentModel
{
    public long Id { get; init; }
    public string? NameAr { get; init; }
    public string? NameEn { get; init; }
    public long? Links { get; init; }
    public string? DataType { get; init; }
    public List<LookupValueModel>? LookupValues { get; init; }
}
