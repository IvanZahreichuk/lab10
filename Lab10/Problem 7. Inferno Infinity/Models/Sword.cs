namespace Lab10.Problem_7._Inferno_Infinity.Models;

public class Sword : Weapon
{
    private const int GemMaxSlots = 3;
    private const int DefaultMinDamage = 4;
    private const int DefaultMaxDamage = 6;

    public Sword(string name, Rarity rarity)
        : base(name, DefaultMinDamage, DefaultMaxDamage, rarity, GemMaxSlots)
    {
    }
}