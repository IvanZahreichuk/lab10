using Lab10.Problem_3._BarracksWars___A_New_Factory;
using Lab10.Problem_3._BarracksWars___A_New_Factory.Interfaces;

public class ReportCommand : Command
{
    [Inject]
    private readonly IRepository repository;

    public ReportCommand(string[] data)
        : base(data)
    {
    }

    public override string Execute()
    {
        string output = this.repository.Statistics;
        return output;
    }
}