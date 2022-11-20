﻿namespace Lab10.Problem_7._Inferno_Infinity.Models
{
    public class Amethyst : Gem
    {
        private const int DefaultStrength = 2;
        private const int DefaultAgility = 8;
        private const int DefaultVitality = 4;

        public Amethyst(Clarity clarity)
            : base(DefaultStrength, DefaultAgility, DefaultVitality, clarity)
        {
        }
    }
}