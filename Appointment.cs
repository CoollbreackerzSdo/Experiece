﻿
using System.Globalization;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
        => DateTime.Parse(appointmentDateDescription, CultureInfo.InvariantCulture);

    public static bool HasPassed(DateTime appointmentDate)
        => appointmentDate < DateTime.Now;

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
        => appointmentDate.Hour is >= 12 and < 18; 
         
    public static string Description(DateTime appointmentDate)
        => $"You have an appointment on {appointmentDate}.";

    public static DateTime AnniversaryDate()
        => new(DateTime.Now.Year,OnOnlyShop.Month,OnOnlyShop.Day);

    private static readonly DateTime OnOnlyShop = new(2012, 9, 15);
}