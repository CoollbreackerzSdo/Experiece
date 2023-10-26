


public static class Darts
{
    public static int Score(double x, double y)
    {
        double distance = Math.Sqrt(x * x + y * y);

        if (distance > 10) return 0;

        if (distance > 5) return 1;

        if(distance > 1) return 5;

        else return 10;
    }
}