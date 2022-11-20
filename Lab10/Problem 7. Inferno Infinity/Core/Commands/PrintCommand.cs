using Lab10.Problem_7._Inferno_Infinity.Core.Attributes;
using Lab10.Problem_7._Inferno_Infinity.Core.Data.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Commands;

public class PrintCommand : CommandProblem7
{
    [Inject] private readonly IWeaponRepository _weaponRepository;

    public PrintCommand(string[] data, IWeaponRepository weaponRepository)
        : base(data)
    {
        this._weaponRepository = weaponRepository;
    }

    public override void Execute()
    {
        string weaponName = this.Data[0];
        Console.WriteLine(this._weaponRepository.PrintWeapon(weaponName));
    }
}