public static class Languages
{
    public static List<string> NewList()
        => [];

    public static List<string> GetExistingLanguages()
        => ["C#", "Clojure", "Elm"];

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);

        return languages;
    }

    public static int CountLanguages(List<string> languages)
        => languages.Count;

    public static bool HasLanguage(List<string> languages, string language)
        => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();

        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (!(languages.Count > 1)) return false;

        if (languages[0] == "C#" || languages[1] == "C#" && languages[0] != "VBA") return true;

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);

        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        var unique = new List<string>();

        foreach (var item in languages)
        {
            if (!unique.Contains(item))
                unique.Add(item);
        }

        return unique.Count == languages.Count;
    }
}