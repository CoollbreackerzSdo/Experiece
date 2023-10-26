class BirdCount
{
    private int[] _BirdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        _BirdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
        => new[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today()
        => _BirdsPerDay[^1];

    public void IncrementTodaysCount()
        => _BirdsPerDay[^1]++;

    public bool HasDayWithoutBirds()
    {
        foreach (var item in _BirdsPerDay)
        {
            if (item == 0)
                return true;
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        var result = 0;

        for (int i = 0; i < numberOfDays; i++)
        {
            result += _BirdsPerDay[i];
        }

        return result;
    }

    public int BusyDays()
    {
        var daysCount = 0;

        foreach (var item in _BirdsPerDay)
        {
            if (item > 4) daysCount++;
        }

        return daysCount;
    }
}
