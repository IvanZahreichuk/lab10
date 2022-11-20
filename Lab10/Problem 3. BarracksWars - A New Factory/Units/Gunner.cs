namespace Lab10.Problem_3._BarracksWars___A_New_Factory.Units;

public class Gunner : Unit
{
    private const int DefaultHealth = 20;
    private const int DefaultDamage = 20;

    public Gunner()
        : base(DefaultHealth, DefaultDamage)
    {
    }
}