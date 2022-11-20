﻿namespace Lab10.Problem_7._Inferno_Infinity.Models;

public class Ruby : Gem
{
    private const int DefaultStrength = 7;
    private const int DefaultAgility = 2;
    private const int DefaultVitality = 5;

    public Ruby(Clarity clarity)
        : base(DefaultStrength, DefaultAgility, DefaultVitality, clarity)
    {
    }
}