using System.Collections;
using System.Globalization;
using System.Text;
using Humanizer;

namespace AjKpi.Database.Common;

public static class Extensions
{
    public static string ToUpperUnderscoreTableName(this Type @this)
    {
        var name = @this.Name.Pluralize();

        var builder = new StringBuilder(name.Length + Math.Min(2, name.Length / 5));
        var previousCategory = default(UnicodeCategory?);

        for (var currentIndex = 0; currentIndex < name.Length; currentIndex++)
        {
            var currentChar = name[currentIndex];
            if (currentChar == '_')
            {
                builder.Append('_');
                previousCategory = null;
                continue;
            }

            var currentCategory = char.GetUnicodeCategory(currentChar);
            switch (currentCategory)
            {
                case UnicodeCategory.UppercaseLetter:
                case UnicodeCategory.TitlecaseLetter:
                    if (
                        previousCategory == UnicodeCategory.SpaceSeparator
                        || previousCategory == UnicodeCategory.LowercaseLetter
                        || previousCategory != UnicodeCategory.DecimalDigitNumber
                        && previousCategory != null
                        && currentIndex > 0
                        && currentIndex + 1 < name.Length
                        && char.IsLower(name[currentIndex + 1])
                    )
                    {
                        builder.Append('_');
                    }

                    currentChar = char.ToLower(currentChar);
                    break;

                case UnicodeCategory.LowercaseLetter:
                case UnicodeCategory.DecimalDigitNumber:
                    if (previousCategory == UnicodeCategory.SpaceSeparator)
                    {
                        builder.Append('_');
                    }

                    break;

                default:
                    if (previousCategory != null)
                    {
                        previousCategory = UnicodeCategory.SpaceSeparator;
                    }

                    continue;
            }

            builder.Append(currentChar);
            previousCategory = currentCategory;
        }

        return builder.ToString().ToUpper();
    }

    public static string ToUpperUnderscoreColumnName(this string @this)
    {
        var name = @this;
        StringBuilder result = new StringBuilder();

        foreach (char c in name)
        {
            if (char.IsUpper(c))
            {
                // Add underscore before uppercase letters (except at the beginning)
                if (result.Length > 0)
                {
                    result.Append('_');
                }
                result.Append(char.ToUpper(c));
            }
            else
            {
                result.Append(char.ToUpper(c));
            }
        }

        return result.ToString().ToUpper();
        // var name = @this;
        //
        // var builder = new StringBuilder(name.Length + Math.Min(2, name.Length / 5));
        // var previousCategory = default(UnicodeCategory?);
        //
        // for (var currentIndex = 0; currentIndex < name.Length; currentIndex++)
        // {
        //     var currentChar = name[currentIndex];
        //     if (currentChar == '_')
        //     {
        //         builder.Append('_');
        //         previousCategory = null;
        //         continue;
        //     }
        //
        //     var currentCategory = char.GetUnicodeCategory(currentChar);
        //     switch (currentCategory)
        //     {
        //         case UnicodeCategory.UppercaseLetter:
        //         case UnicodeCategory.TitlecaseLetter:
        //             if (
        //                 previousCategory == UnicodeCategory.SpaceSeparator
        //                 || previousCategory == UnicodeCategory.LowercaseLetter
        //                 || previousCategory != UnicodeCategory.DecimalDigitNumber
        //                 && previousCategory != null
        //                 && currentIndex > 0
        //                 && currentIndex + 1 < name.Length
        //                 && char.IsLower(name[currentIndex + 1])
        //             )
        //             {
        //                 builder.Append('_');
        //             }
        //
        //             currentChar = char.ToLower(currentChar);
        //             break;
        //
        //         case UnicodeCategory.LowercaseLetter:
        //         case UnicodeCategory.DecimalDigitNumber:
        //             if (previousCategory == UnicodeCategory.SpaceSeparator)
        //             {
        //                 builder.Append('_');
        //             }
        //
        //             break;
        //
        //         default:
        //             if (previousCategory != null)
        //             {
        //                 previousCategory = UnicodeCategory.SpaceSeparator;
        //             }
        //
        //             continue;
        //     }
        //
        //     builder.Append(currentChar);
        //     previousCategory = currentCategory;
        // }
        //
        // return builder.ToString().ToUpper();
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> array, Action<T> act)
    {
        foreach (var i in array)
            act(i);
        return array;
    }

    public static IEnumerable<T> ForEach<T>(this IEnumerable arr, Action<T> act)
    {
        return arr.Cast<T>().ForEach<T>(act);
    }

    public static IEnumerable<RT> ForEach<T, RT>(this IEnumerable<T> array, Func<T, RT> func)
    {
        var list = new List<RT>();
        foreach (var i in array)
        {
            var obj = func(i);
            if (obj != null)
                list.Add(obj);
        }
        return list;
    }
}
