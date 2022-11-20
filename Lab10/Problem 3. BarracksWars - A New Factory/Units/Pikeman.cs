namespace Lab10.Problem_3._BarracksWars___A_New_Factory.Units;

public class Pikeman : Unit
{
    private const int DefaultHealth = 30;
    private const int DefaultDamage = 15;

    public Pikeman()
        : base(DefaultHealth, DefaultDamage)
    {
    }
}