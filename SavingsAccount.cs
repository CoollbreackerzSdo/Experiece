
static class SavingsAccount
{
    public static float InterestRate(decimal balance) 
        => balance switch
    {
        < 0 => 3.213f,
        < 1000 => 0.5f,
        < 5000 => 1.621f,
        _ => 2.475f
    };

    public static decimal Interest(decimal balance) 
        => (decimal)GetIts(balance) * balance * 1;

    public static decimal AnnualBalanceUpdate(decimal balance)
        => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;

        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);

            years++;
        }

        return years;
    }

    private static double GetIts(decimal balance)
        => balance switch
        {
            < 0 => 0.03213f,
            < 1000 => 0.005f,
            < 5000 => 0.01621f,
           _ => 0.02475f
        };
}