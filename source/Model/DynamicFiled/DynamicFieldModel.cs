namespace AjKpi.Model;

public sealed record DynamicFieldModel
{
    public long Id { get; init; }
    public LocalizationModel? Name { get; init; }
    public LookupValueModel? EntityType { get; init; }
    public LookupValueModel? DynamicFieldType { get; init; }
    public string? DynamicFieldRegex { get; init; }
    public long? DynamicFieldMinValue { get; init; }
    public long? DynamicFieldMaxValue { get; init; }
    public LookupValueModel? DynamicFieldLookupType { get; init; }
}
