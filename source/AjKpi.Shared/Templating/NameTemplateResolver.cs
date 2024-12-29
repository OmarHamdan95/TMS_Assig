using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Shared.Generator;

namespace Shared.Templating;

public class NameTemplateResolver
{
    private static Regex _pattern = new(@"{{(?<token>\$?[^}]*)}}", RegexOptions.None, TimeSpan.FromSeconds(5));

     public static List<string>? Resolve(string template, JToken data, long existingCount = 0)
        {
            if (template == null)
            {
                return new List<string>();
            }

            var tokens = _pattern.Matches(template).Select(e => e.Groups["token"].Value).ToList();
            if (tokens.Count(t => t.Contains("[*]")) > 1)
            {
                throw new Exception("ONLY_ONE_ARRAY_TOKEN_ALLOWED");
            }

            var arrayToken = tokens.FirstOrDefault(t => t.Contains("[*]"));
            string?[] arrayTokenValues = Array.Empty<string>();
            if (arrayToken != null)
            {
                arrayTokenValues = data.SelectTokens(arrayToken).Values<string>().ToArray();
            }

            if (string.IsNullOrWhiteSpace(template))
            {
                return null;
            }

            var date = $"{DateTime.UtcNow:yyyyMMdd}";

            var results = new List<string>();
            for (var i = 0; i < (arrayToken != null ? arrayTokenValues.Length : 1); i++)
            {
                results.Add(_pattern.Replace(template, m =>
                {
                    var token = m.Groups["token"].Value;

                    // Array token.
                    if (token.Contains("[*]"))
                    {
                        return arrayTokenValues[i] ?? string.Empty;
                    }

                    // {{property.extraProperty}}
                    if (!token.StartsWith('$'))
                    {
                        return data.SelectToken(token)?.Value<string>() ?? string.Empty;
                    }

                    // {{$date}}
                    var reservedToken = token[1..];
                    if (reservedToken == "date")
                    {
                        return date;
                    }

                    // {{$rnd:10}}
                    if (reservedToken.StartsWith("rnd:"))
                    {
                        var count = int.Parse(reservedToken.Split(':')[1]);

                        return RandomGenerator.RandomNumeric(count);
                    }

                    // {{$seq:5}}
                    if (reservedToken.StartsWith("seq:"))
                    {
                        var length = int.Parse(reservedToken.Split(':')[1]);
                        existingCount = existingCount % Convert.ToInt64(new string('9', length));

                        return (existingCount + 1).ToString().PadLeft(length, '0');
                    }

                    return $"{{{token}}}";
                }));
            }

            return results;
        }
}
