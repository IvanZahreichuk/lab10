using Lab10.Problem_7._Inferno_Infinity.Core.Attributes;
using Lab10.Problem_7._Inferno_Infinity.Core.Data.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Core.Factories.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Commands;

public class AddCommandProblem7 : CommandProblem7
{
    [Inject] private readonly IGemFactory _gemFactory;
    [Inject] private readonly IWeaponRepository _weaponRepository;

    public AddCommandProblem7(string[] data, IGemFactory gemFactory, IWeaponRepository weaponRepository)
        : base(data)
    {
        this._gemFactory = gemFactory;
        this._weaponRepository = weaponRepository;
    }

    public override void Execute()
    {
        string weaponName = this.Data[0];
        int index = int.Parse(this.Data[1]);

        var gemData = this.Data[2].Split();
        string clarity = gemData[0];
        string gemType = gemData[1];

        IGem gem = this._gemFactory.Create(clarity, gemType);
        IWeapon weapon = this._weaponRepository.GetWeapon(weaponName);
        weapon.AddSocked(gem, index);
    }
}