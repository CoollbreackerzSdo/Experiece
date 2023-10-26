static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed is 0) return 0;

        else if (speed >= 1 && speed < 5) return 1;

        else if (speed >= 5 && speed  < 9) return .90;

        else if (speed is 9) return .80;

        else return .77;
    }

    public static double ProductionRatePerHour(int speed)
        => speed * 221 * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed)
        => (int)(ProductionRatePerHour(speed) / 60);
}