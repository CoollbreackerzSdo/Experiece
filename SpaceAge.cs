public class SpaceAge
{

    public SpaceAge(int seconds)
    {
        _YearsInOurs = seconds;
    }

    public double OnEarth()
        => _YearsInOurs / (_SecondsOnTheYear * 1);

    public double OnMercury()
        => _YearsInOurs / (_SecondsOnTheYear * 0.2408467);

    public double OnVenus()
        => _YearsInOurs / (_SecondsOnTheYear * 0.61519726);

    public double OnMars()
        => _YearsInOurs / (_SecondsOnTheYear * 1.8808158);

    public double OnJupiter()
        => _YearsInOurs / (_SecondsOnTheYear * 11.862615);

    public double OnSaturn()
        => _YearsInOurs / (_SecondsOnTheYear * 29.447498);

    public double OnUranus()
        => _YearsInOurs / (_SecondsOnTheYear * 84.016846);

    public double OnNeptune()
        => _YearsInOurs / (_SecondsOnTheYear * 164.79132);

    private readonly double _SecondsOnTheYear = 31_557_600;
    private readonly double _YearsInOurs;
}