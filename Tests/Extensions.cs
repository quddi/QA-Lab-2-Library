using System.Text;

namespace Tests;

public static class Extensions
{
    private static readonly Random Random = new();
    private static readonly StringBuilder StringBuilder = new();
    private static readonly string[] Domains = { "gmail.com", "yahoo.com", "hotmail.com", "mail.ru", "yandex.ru" };
    private static readonly IList<char> Chars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

    public static string GetRandomEmail()
    {
        var username = GetRandomString(5, 10);

        var domain = Domains.GetRandom<string>();

        return string.Format($"{username}@{domain}");
    }

    public static string GetRandomString(int length)
    {
        return GetRandomString(length, length);
    }

    public static string GetRandomString(int minLength, int maxLength)
    {
        for (int i = 0; i < Random.Next(minLength, maxLength); i++)
        {
            StringBuilder.Append(Chars.GetRandom());
        }

        var result = StringBuilder.ToString();

        StringBuilder.Clear();

        return result;
    }

    public static T GetRandom<T>(this IList<T> collection)
    {
        var randomIndex = Random.Next(0, collection.Count);

        return collection[randomIndex];
    }

    public static object GetRandom(this Array collection)
    {
        var randomIndex = Random.Next(0, collection.Length);

        return collection.GetValue(randomIndex)!;
    }
}