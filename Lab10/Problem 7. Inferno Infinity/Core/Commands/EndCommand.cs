namespace Lab10.Problem_7._Inferno_Infinity.Core.Commands;

public class EndCommand : CommandProblem7
{
    public EndCommand(string[] data)
        : base(data)
    {
    }

    public override void Execute()
    {
        Environment.Exit(0);
    }
}