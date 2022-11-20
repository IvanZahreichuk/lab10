using Lab10.Problem_7._Inferno_Infinity.Core.Data.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Data;

public class WeaponRepository : IWeaponRepository
{
    readonly IDictionary<string, IWeapon> _weapons;

    public WeaponRepository()
    {
        this._weapons = new Dictionary<string, IWeapon>();
    }

    public void AddWeapon(IWeapon weapon)
    {
        if (!_weapons.ContainsKey(weapon.Name))
        {
            _weapons.Add(weapon.Name.ToLower(), weapon);
        }
    }

    public IWeapon GetWeapon(string name)
    {
        name = name.ToLower();
        if (!this._weapons.ContainsKey(name))
        {
            throw new ArgumentException("Weapon repository does not contain this weapon!");
        }

        return _weapons[name];
    }

    public string PrintWeapon(string weaponName)
    {
        IWeapon weapon = this._weapons.FirstOrDefault(kvp => kvp.Key.ToLower() == weaponName.ToLower()).Value;
        return weapon.ToString();
    }
}