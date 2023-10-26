public class Player
{
    public int RollDie()
        => Random.Shared.Next(1, 18);

    public double GenerateSpellStrength()
        => Random.Shared.Next(0,100);
}
