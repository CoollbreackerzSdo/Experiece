public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        for (int i = 0; i < _Colors.Length; i++)
        {
            if (_Colors[i] == color) return i;
        }

        return -1;
    }
    public static string[] Colors() => _Colors;
    private readonly static string[] _Colors = new string[]
    {
        "Black",
        "Brown",
        "Red",
        "Orange",
        "Yellow",
        "Green",
        "Blue",
        "Violet",
        "Grey",
        "White",
    };
}