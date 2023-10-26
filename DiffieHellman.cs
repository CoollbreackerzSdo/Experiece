using System.Numerics;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP)
        => Random.Shared.Next(2,(int)primeP - 1);

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey)
        => (primeG ^ privateKey % primeP);
    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey)
        => BigInteger.Pow(publicKey, (int)privateKey) % primeP;
}