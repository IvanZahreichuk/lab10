namespace Lab10.Problem_7._Inferno_Infinity.Models;

public class Axe : Weapon
{
    private const int GemMaxSlots = 4;
    private const int DefaultMinDamage = 5;
    private const int DefaultMaxDamage = 10;

    public Axe(string name, Rarity rarity)
        : base(name, DefaultMinDamage, DefaultMaxDamage, rarity, GemMaxSlots)
    {
    }
}