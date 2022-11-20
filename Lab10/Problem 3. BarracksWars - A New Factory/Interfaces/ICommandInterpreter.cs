namespace Lab10.Problem_3._BarracksWars___A_New_Factory.Interfaces;

public interface ICommandInterpreter
{
    IExecutable InterpretCommand(string[] data, string commandName);
}