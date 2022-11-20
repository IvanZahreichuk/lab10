using System.Text;
using Lab10.Problem_3._BarracksWars___A_New_Factory.Interfaces;

namespace Lab10.Problem_3._BarracksWars___A_New_Factory;

public class UnitRepository : IRepository
{
    private readonly IDictionary<string, int> _amountOfUnits;

    public UnitRepository()
    {
        this._amountOfUnits = new SortedDictionary<string, int>();
    }

    public string Statistics
    {
        get
        {
            StringBuilder statBuilder = new StringBuilder();

            foreach (KeyValuePair<string, int> entry in this._amountOfUnits)
            {
                string formatedEntry = $"{entry.Key} -> {entry.Value}";
                statBuilder.AppendLine(formatedEntry);
            }

            return statBuilder.ToString().Trim();
        }
    }

    public void AddUnit(IUnit unit)
    {
        string unitType = unit.GetType().Name;

        if (!this._amountOfUnits.ContainsKey(unitType))
        {
            this._amountOfUnits.Add(unitType, 0);
        }

        this._amountOfUnits[unitType]++;
    }

    public void RemoveUnit(string unitType)
    {
        if (this._amountOfUnits.ContainsKey(unitType) && this._amountOfUnits[unitType] > 0)
        {
            this._amountOfUnits[unitType]--;
        }
        else
        {
            throw new ArgumentException("No such units in repository.");
        }
    }
}