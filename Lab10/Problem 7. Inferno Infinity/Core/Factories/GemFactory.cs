using System.Reflection;
using Lab10.Problem_7._Inferno_Infinity.Core.Factories.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Models;
using Lab10.Problem_7._Inferno_Infinity.Models.Contracts;

namespace Lab10.Problem_7._Inferno_Infinity.Core.Factories;

public class GemFactory : IGemFactory
{
    public IGem Create(string gemClarity, string gemType)
    {
        Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), gemClarity);

        var assembly = Assembly.GetExecutingAssembly();
        var type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == gemType.ToLower());

        if (type == null)
        {
            throw new ArgumentException("Invalid gem type!");
        }

        IGem gem = (IGem)Activator.CreateInstance(type, new object[] { clarity });

        return gem;
    }
}