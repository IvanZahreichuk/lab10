using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Factories.Contracts;

public interface IWeaponFactory
{
    IWeapon Create(string weaponRarity, string weaponType, string weaponName);
}