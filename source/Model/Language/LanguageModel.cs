namespace AjKpi.Model;

public sealed record LanguageModel
{
    public long Id { get; init; }
    public string? Code { get; init; }
    public string? LangFlag { get; init; }
}
