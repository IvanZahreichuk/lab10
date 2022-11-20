using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Models;

public abstract class Gem : IGem
{
    private int _strength;
    private int _agility;
    private int _vitality;
    private Clarity clarity;

    protected Gem(int strength, int agility, int vitality, Clarity clarity)
    {
        this._strength = strength;
        this._agility = agility;
        this._vitality = vitality;
        this.clarity = clarity;
    }

    public virtual int Strength
    {
        get { return this._strength + (int)Clarity; }
        private set { this._strength = value; }
    }

    public virtual int Agility
    {
        get { return this._agility + (int)Clarity; }
        private set { this._agility = value; }
    }

    public virtual int Vitality
    {
        get { return this._vitality + (int)Clarity; }
        private set { this._vitality = value; }
    }

    public virtual Clarity Clarity
    {
        get { return this.clarity; }
        private set { this.clarity = value; }
    }
}