

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        return BitConverter.GetBytes(reading);
    }

    public static long FromBuffer(byte[] buffer)
    {
        return BitConverter.ToInt64(buffer);
    }
}