class Wizard : Character
{
    public Wizard() : base("TODO")
    {
        _IsPreparade = false;
    }

    public override int DamagePoints(Character target)
    {
        if (_IsPreparade)
        {
            _IsPreparade = false;
            return 12;
        }

        return 3;
    }

    public void PrepareSpell()
        => _IsPreparade = true;

    public override bool Vulnerable()
        => !_IsPreparade;

    private protected bool _IsPreparade;
}