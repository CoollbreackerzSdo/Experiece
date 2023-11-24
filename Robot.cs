public class Robot 
{
    static HashSet<string> _Names = new HashSet<string>();
    static Random _Rnd = new Random();
    public string _Name { get; private set; }
    public Robot()
    {
        Reset();
    }

    static string GenerateName()
    {
        while (true)
        {
            var n = string.Format("{0}{1}{2:D3}", (char) ('A' + _Rnd.Next(26)), (char) ('A' + _Rnd.Next(26)), _Rnd.Next(1000));

            if (!_Names.Contains(n))
            {
                _Names.Add(n);
                return n;
            }
        }
    }
    public void Reset()
    {
        _Name = GenerateName();
    }
}