using System;
using System.Linq;
using System.Reflection;
using Lab10.Problem_3._BarracksWars___A_New_Factory.Interfaces;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        // Getting the namespace where the units reside
        string unitsNamespace = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Select(t => t.Namespace)
            .Distinct()
            .Where(n => n != null)
            .FirstOrDefault(n => n.Contains("Units"));

        Type typeOfUnit = Type.GetType($"{unitsNamespace}.{unitType}");
        IUnit instanceOfUnit = (IUnit)Activator.CreateInstance(typeOfUnit);

        return instanceOfUnit;
    }
}