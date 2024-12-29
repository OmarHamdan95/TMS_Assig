namespace AjKpi.Model;

public sealed record  LookupValueModel
{
    public string? Code { get; set; }
    public string? Color { get; set; }
    public long? Id { get; init; }
    public long? LookupId { get; init; }

    public LookupValueParentModel? Parent { get; init; }
    public long? Order { get; init; }
    public string? NameAr { get; init; }
    public string? NameEn { get; init; }
}

public sealed record LookupValueParentModel
{
    public long? Id { get; init; }
    public long? Order { get; init; }
    public string? NameAr { get; init; }
    public string? NameEn { get; init; }
}
