public class Meetup
{
    private int _month;
    private int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime meetupDate = new DateTime(_year, _month, 1);

        while (meetupDate.DayOfWeek != dayOfWeek)
        {
            meetupDate = meetupDate.AddDays(1);
        }

        switch (schedule)
        {
            case Schedule.First:
                while (meetupDate.Month == _month && meetupDate.DayOfWeek != dayOfWeek)
                {
                    meetupDate = meetupDate.AddDays(7);
                }
                break;
            case Schedule.Second:
                meetupDate = DayOfWeekCount(meetupDate, dayOfWeek, 2);
                break;
            case Schedule.Third:
                meetupDate = DayOfWeekCount(meetupDate, dayOfWeek, 3);
                break;
            case Schedule.Fourth:
                meetupDate = DayOfWeekCount(meetupDate, dayOfWeek, 4);
                break;
            case Schedule.Last:
                while (meetupDate.Month == _month)
                {
                    DateTime nextWeek = meetupDate.AddDays(7);
                    if (nextWeek.Month != _month)
                        break;
                    meetupDate = nextWeek;
                }
                break;
            case Schedule.Teenth:
                while (meetupDate.Day <= 19)
                {
                    if (meetupDate.DayOfWeek == dayOfWeek && meetupDate.Day > 12) break;
                    meetupDate = meetupDate.AddDays(1);
                }
                break;
        }

        return meetupDate;
    }

    private DateTime DayOfWeekCount(DateTime date, DayOfWeek dayOfWeek, int count)
    {
        int currentCount = 1;
        while (currentCount < count)
        {
            date = date.AddDays(7);
            if (date.Month != _month || date.DayOfWeek != dayOfWeek)
                return default(DateTime); // Return default value if count is not achieved in the current month
            currentCount++;
        }
        return date;
    }
}
public enum Schedule
{
    First,
    Second,
    Third,
    Fourth,
    Last,
    Teenth
}