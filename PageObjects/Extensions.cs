using System.Text;

namespace PageObjects;

public static class Extensions
{
    private const string Name = "Nikita";
    private const string Surname = "Andrushko";
    private const string Password = "123465789";
    private const string Email = "alemkhf12@gmail.com";

    private static readonly Random Random = new();
    private static readonly StringBuilder StringBuilder = new();
    private static readonly string[] Domains = { "gmail.com", "yahoo.com", "hotmail.com", "mail.ru", "yandex.ru" };
    private static readonly char[] Chars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

    private static string GetRandomEmail()
    {
        for (int i = 0; i < Random.Next(5, 10); i++)
        {
            StringBuilder.Append(Chars.GetRandom());
        }

        var username = StringBuilder.ToString();

        StringBuilder.Clear();

        var domain = Domains.GetRandom();

        return string.Format($"{username}@{domain}");
    }

    private static T GetRandom<T>(this IList<T> collection)
    {
        var randomIndex = Random.Next(0, collection.Count);

        return collection[randomIndex];
    }
}