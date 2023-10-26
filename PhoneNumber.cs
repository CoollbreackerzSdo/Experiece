public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool IsNewYork = phoneNumber[..3] is "212";

        bool isFake = phoneNumber[4..7] is not "555";
        
        string LocalNumber = phoneNumber[^4..];

        return (IsNewYork, isFake, LocalNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
        => phoneNumberInfo.IsFake && phoneNumberInfo.IsNewYork;
}