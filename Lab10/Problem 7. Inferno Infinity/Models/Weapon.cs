using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Models;

public abstract class Weapon : IWeapon
{
    private readonly string _name;
    private int _minDamage;
    private int _maxDamage;
    private IGem[] _gems;
    private int _strength;
    private int _agility;
    private int _vitality;
    private Rarity _rarity;

    protected Weapon(string name, int minDamage, int maxDamage, Rarity rarity, int gemSlots)
    {
        this._name = name;
        this.MinDamage = minDamage;
        this.MaxDamage = maxDamage;
        this.Rarity = rarity;
        this._gems = new IGem[gemSlots];
    }

    public virtual string Name => this._name;

    public virtual int MinDamage
    {
        get { return this._minDamage * (int)this.Rarity; }
        protected set { this._minDamage = value; }
    }

    public virtual int MaxDamage
    {
        get { return this._maxDamage * (int)this.Rarity; }
        protected set { this._maxDamage = value; }
    }

    public virtual Rarity Rarity
    {
        get { return this._rarity; }
        private set { this._rarity = value; }
    }

    public IReadOnlyCollection<IGem> Gems
    {
        get => this._gems.ToList().AsReadOnly();
        private set { this._gems = value.ToArray(); }
    }

    public virtual int ModifiedMinDamage => this.MinDamage + this.Strength * 2 + this.Agility * 1;

    public virtual int ModifiedMaxDamage => this.MaxDamage + this.Strength * 3 + this.Agility * 4;

    public virtual int Strength
    {
        get => this._strength;
        private set
        {
            if (value < 0)
            {
                this._strength = 0;
            }
            else
            {
                this._strength = value;
            }
        }
    }

    public virtual int Agility
    {
        get => this._agility;
        private set
        {
            if (value < 0)
            {
                this._agility = 0;
            }
            else
            {
                this._agility = value;
            }
        }
    }

    public virtual int Vitality
    {
        get => this._vitality;
        private set
        {
            if (value < 0)
            {
                this._vitality = 0;
            }
            else
            {
                this._vitality = value;
            }
        }
    }

    public virtual void AddSocked(IGem gem, int index)
    {
        if (index >= 0 && index < _gems.Length)
        {
            if (this._gems[index] == null)
            {
                this._gems[index] = gem;
                this.Strength += gem.Strength;
                this.Agility += gem.Agility;
                this.Vitality += gem.Vitality;
            }
            else
            {
                this.RemoveSocked(index);
                this._gems[index] = gem;
                this.Strength += gem.Strength;
                this.Agility += gem.Agility;
                this.Vitality += gem.Vitality;
            }
        }
    }

    public virtual void RemoveSocked(int index)
    {
        if (index >= 0 && index < _gems.Length)
        {
            IGem gem = this._gems[index];
            this._gems[index] = null;
            this.Strength -= gem.Strength;
            this.Agility -= gem.Agility;
            this.Vitality -= gem.Vitality;
        }
    }

    public override string ToString()
    {
        return
            $"{this.Name}: {this.ModifiedMinDamage}-{this.ModifiedMaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }
}