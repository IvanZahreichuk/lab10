using Lab10.Problem_7._Inferno_Infinity.Core.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Commands;

public abstract class CommandProblem7 : IExecutableProblem7
{
    private readonly string[] _data;

    protected CommandProblem7(string[] data)
    {
        this._data = data;
    }

    public virtual string[] Data
    {
        get => this._data;
    }

    public abstract void Execute();
}