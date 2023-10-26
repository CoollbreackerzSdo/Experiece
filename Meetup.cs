public class Meetup
{
    public Meetup(int month, int year)
    {
        _MeetupDate = (month, year);
    }
    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var date = new DateTime(_MeetupDate.Year, _MeetupDate.Month,1);


        return date;
    }
    private readonly (int Month, int Year) _MeetupDate;
}
public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}