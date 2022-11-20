namespace Lab10.Problem_7._Inferno_Infinity.Core.Contracts;

public interface ICommandInterpreterProblem7
{
    IExecutableProblem7 InterpretCommand(string commandName, string[] data);
}