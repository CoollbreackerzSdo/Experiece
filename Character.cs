abstract class Character
{
    protected Character(string characterType) { }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
        => false;

    public override string ToString()
        => $"Character is a {GetType()}";
}
