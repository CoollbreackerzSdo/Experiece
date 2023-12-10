public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        if (string.IsNullOrEmpty(word)) return true;
        {
            word = word.ToLower();

            var elements = new HashSet<char>();

            foreach (var item in word)
            {
                if (item == ' ' || item == '-') continue;

                else if (elements.Contains(item)) return false;

                elements.Add(item);
            }

            return true;
        }
    }
}