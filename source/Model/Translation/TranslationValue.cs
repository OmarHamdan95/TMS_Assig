namespace AjKpi.Model;

public sealed record TranslationValueModel
{
    public long Id { get; init; }
    public string Code { get; init; }
    public string TransaltionValue { get; init; }
    public LanguageModel Language { get; init; }

}

public sealed record TranslationValueModelQuery
{
    public long Id { get; init; }
    public string Code { get; init; }
    public string TransaltionValue { get; init; }
    public LanguageModel Language { get; init; }
    public string? LanguageId { get; init; }
}
