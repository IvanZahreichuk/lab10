namespace Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

public interface IWeapon
{
    string Name { get; }

    int MinDamage { get; }

    int ModifiedMinDamage { get; }

    int MaxDamage { get; }

    int ModifiedMaxDamage { get; }

    Rarity Rarity { get; }

    IReadOnlyCollection<IGem> Gems { get; }

    void AddSocked(IGem gem, int index);

    void RemoveSocked(int index);
}