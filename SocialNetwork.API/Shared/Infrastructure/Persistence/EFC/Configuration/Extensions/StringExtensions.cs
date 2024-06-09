using Humanizer;

namespace SocialNetwork.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class StringExtensions
{
    // Poniendo los tablas en snake case
    public static string ToSnakeCase(this string text)
    {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;

            yield return char.ToLower(e.Current);

            while (e.MoveNext())
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
        }
    }

    // Convirtiendo el nombre de las tablas de singular a plural
    public static string ToPlural(this string text)
    {
        return text.Pluralize(inputIsKnownToBeSingular:false);
    }
}