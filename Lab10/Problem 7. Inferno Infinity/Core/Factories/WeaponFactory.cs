using System.Reflection;
using Lab10.Problem_7._Inferno_Infinity.Core.Factories.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Models;
using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Factories;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon Create(string weaponRarity, string weaponType, string weaponName)
    {
        Rarity rarity = (Rarity)Enum.Parse(typeof(Rarity), weaponRarity, true);

        var assembly = Assembly.GetExecutingAssembly();
        var type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == weaponType.ToLower());

        if (type == null)
        {
            throw new ArgumentException($"Invalid weapon type!");
        }

        var weapon = (IWeapon)Activator.CreateInstance(type, new object[] { weaponName, rarity });

        return weapon;
    }
}