namespace Lab10.Problem_3._BarracksWars___A_New_Factory.Units;

public class Swordsman : Unit
{
    private const int DefaultHealth = 40;
    private const int DefaultDamage = 13;

    public Swordsman()
        : base(DefaultHealth, DefaultDamage)
    {
    }
}