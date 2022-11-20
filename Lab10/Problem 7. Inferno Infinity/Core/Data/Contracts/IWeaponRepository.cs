using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Data.Contracts;

public interface IWeaponRepository
{
    void AddWeapon(IWeapon weapon);

    IWeapon GetWeapon(string name);

    string PrintWeapon(string weaponName);
}