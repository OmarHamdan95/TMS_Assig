namespace AjKpi.Domain.Common;

public class LocalizedText : List<Localization>
{
}

public class Localization
{
    public Localization()
    {
    }

    public Localization(string culture, string text)
    {
        Culture = culture;
        Text = text;
    }

    public string Culture { get; set; }

    public string Text { get; set; }
}


