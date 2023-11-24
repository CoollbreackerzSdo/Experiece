

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        int bytesActives = BitConverter.GetBytes(reading).Length;

        if (long.IsPositive(reading))
        {
            buffer[0] = (byte)bytesActives;
            Buffer.BlockCopy(BitConverter.GetBytes(reading), 0, buffer,1, bytesActives);
        }
        else
        {
            buffer[0] = (byte)(256 - bytesActives);
            byte[] tempBuffer = BitConverter.GetBytes(reading);
            Buffer.BlockCopy(tempBuffer, tempBuffer.Length - bytesActives, buffer, 1, bytesActives);
        }

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length < 1)
        {
            throw new ArgumentException("Buffer is null or empty");
        }

        int bytesToUse = buffer[0]; // Obtiene el primer byte que indica el número de bytes utilizados
        long result = 0;

        if (bytesToUse >= 0 && bytesToUse <= 8)
        {
            bool isNegative = bytesToUse > 128; // Verifica si el número es negativo

            if (isNegative)
            {
                bytesToUse = 256 - bytesToUse; // Ajusta el número de bytes utilizados si es negativo
            }

            byte[] tempBuffer = new byte[8]; // Usamos un buffer temporal de 8 bytes para asegurarnos de obtener los 8 bytes del long

            // Copia los bytes del buffer original al buffer temporal
            Buffer.BlockCopy(buffer, 1, tempBuffer, 8 - bytesToUse, bytesToUse);

            // Convierte el buffer temporal a un número long
            result = BitConverter.ToInt64(tempBuffer, 0);

            if (isNegative)
            {
                result = -result; // Si es negativo, cambiamos el signo del número
            }
        }
        else
        {
            throw new ArgumentException("Invalid byte count in the buffer");
        }

        return result;
    }
}
