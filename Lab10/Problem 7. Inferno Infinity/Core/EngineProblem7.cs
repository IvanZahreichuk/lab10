using Lab10.Problem_7._Inferno_Infinity.Core.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core;

public class EngineProblem7 : IRunnableProblem7
{
    private readonly ICommandInterpreterProblem7 _commandInterpreter;

    public EngineProblem7(ICommandInterpreterProblem7 commandInterpreter)
    {
        this._commandInterpreter = commandInterpreter;
    }


    public void Run()
    {
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string[] data = input.Split(';');
                string commandName = data[0];
                string[] commandData = data.Skip(1).ToArray();
                IExecutableProblem7 result = _commandInterpreter.InterpretCommand(commandName, commandData);
                result.Execute();
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);
            }
        }
    }
}