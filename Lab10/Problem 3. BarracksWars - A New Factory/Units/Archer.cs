namespace Lab10.Problem_3._BarracksWars___A_New_Factory.Units;

public class Archer : Unit
{
    private const int DefaultHealth = 25;
    private const int DefaultDamage = 7;

    public Archer()
        : base(DefaultHealth, DefaultDamage)
    {
    }
}