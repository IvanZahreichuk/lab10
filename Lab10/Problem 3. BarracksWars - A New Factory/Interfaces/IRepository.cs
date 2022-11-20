namespace Lab10.Problem_3._BarracksWars___A_New_Factory.Interfaces;

public interface IRepository
{
    string Statistics { get; }

    void RemoveUnit(string unitType);

    void AddUnit(IUnit unit);
}