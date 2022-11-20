using Lab10.Problem_7._Inferno_Infinity.Core.Attributes;
using Lab10.Problem_7._Inferno_Infinity.Core.Data.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Core.Factories.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Commands;

public class CreateCommand : CommandProblem7
{
    [Inject] private readonly IWeaponFactory _weaponFactory;

    [Inject] private readonly IWeaponRepository _weaponRepository;

    public CreateCommand(string[] data, IWeaponFactory weaponFactory, IWeaponRepository weaponRepository)
        : base(data)
    {
        this._weaponFactory = weaponFactory;
        this._weaponRepository = weaponRepository;
    }

    public override void Execute()
    {
        string[] weaponData = this.Data[0].Split();
        string weaponRarity = weaponData[0];
        string weaponType = weaponData[1];
        string weaponName = Data[1];

        IWeapon weapon = this._weaponFactory.Create(weaponRarity, weaponType, weaponName);
        this._weaponRepository.AddWeapon(weapon);
    }
}