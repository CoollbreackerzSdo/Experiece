public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) => shirtNum switch
    {
        1 => "goalie",
        2 => "left back",
        3 & 4 => "center back",
        5 => "right back",
        (6 or 7 or 8) => "midfielder",
        9 => "left wing",
        10 => "striker",
        11 => "right wing",
        _ => string.Empty
    };

    public static string AnalyzeOffField(object report) => report switch
    {
        string text => text,
        int number => $"There are {number} supporters at the match.",
        Foul => "The referee deemed a foul.",
        Injury model => $"Oh no! Player {model.NumberPlayer} is injured. Medics are on the field.",
        Incident => "An incident happened.",
        _ => string.Empty,
    };
}
