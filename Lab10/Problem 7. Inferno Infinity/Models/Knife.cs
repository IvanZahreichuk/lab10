﻿namespace Lab10.Problem_7._Inferno_Infinity.Models;

public class Knife : Weapon
{
    private const int GemMaxSlots = 2;
    private const int DefaultMinDamage = 3;
    private const int DefaultMaxDamage = 4;

    public Knife(string name, Rarity rarity)
        : base(name, DefaultMinDamage, DefaultMaxDamage, rarity, GemMaxSlots)
    {
    }
}