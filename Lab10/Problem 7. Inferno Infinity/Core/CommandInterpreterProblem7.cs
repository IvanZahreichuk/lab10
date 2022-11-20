using System.Reflection;
using Lab10.Problem_7._Inferno_Infinity.Core.Attributes;
using Lab10.Problem_7._Inferno_Infinity.Core.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core;

public class CommandInterpreterProblem7 : ICommandInterpreterProblem7
{
    private readonly IServiceProvider _service;

    public CommandInterpreterProblem7(IServiceProvider service)
    {
        this._service = service;
    }

    public IExecutableProblem7 InterpretCommand(string commandName, string[] commandData)
    {
        var classCommandName = (commandName + "Command");

        var assembly = Assembly.GetExecutingAssembly();

        var type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == classCommandName.ToLower());

        if (type == null)
        {
            throw new ArgumentException("Invalid command type!");
        }

        FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.CustomAttributes.Any(a => a.AttributeType.Name == typeof(InjectAttribute).Name))
            .ToArray();

        object[] getFIelds = fieldsToInject.Select(f => _service.GetService(f.FieldType)).ToArray();

        object[] ctorParams = new object[] { commandData }.Concat(getFIelds).ToArray();

        var commandInstance = (IExecutableProblem7)Activator.CreateInstance(type, ctorParams);

        return commandInstance;
    }
}