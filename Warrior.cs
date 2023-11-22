class Warrior : Character
{
    public Warrior() : base("TODO") { }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }

        return 6;
    }
}
