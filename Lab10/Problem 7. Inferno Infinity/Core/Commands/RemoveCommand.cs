using Lab10.Problem_7._Inferno_Infinity.Core.Attributes;
using Lab10.Problem_7._Inferno_Infinity.Core.Data.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Commands;

public class RemoveCommand : CommandProblem7
{
    [Inject] private readonly IWeaponRepository _weaponRepository;

    public RemoveCommand(string[] data, IWeaponRepository weaponRepository)
        : base(data)
    {
        this._weaponRepository = weaponRepository;
    }

    public override void Execute()
    {
        var weaponName = this.Data[0];
        var index = int.Parse(this.Data[1]);
        var weapon = this._weaponRepository.GetWeapon(weaponName);

        weapon.RemoveSocked(index);
    }
}