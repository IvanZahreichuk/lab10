using System.Reflection;
using System.Text;
using Lab10;
using Lab10.Problem_3._BarracksWars___A_New_Factory;
using Lab10.Problem_3._BarracksWars___A_New_Factory.Interfaces;
using Lab10.Problem_6._Traffic_Lights;
using Lab10.Problem_7._Inferno_Infinity.Core;
using Lab10.Problem_7._Inferno_Infinity.Core.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Core.Data;
using Lab10.Problem_7._Inferno_Infinity.Core.Data.Contracts;
using Lab10.Problem_7._Inferno_Infinity.Core.Factories;
using Lab10.Problem_7._Inferno_Infinity.Core.Factories.Contracts;
using Microsoft.Extensions.DependencyInjection;

var loopBreak = true;
while (loopBreak)
{
    Console.WriteLine("Select the problem(1-10) or exit(0):");

    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            Problem1();
            break;
        case 2:
            Problem2();
            break;
        case 3:
            Problem3_4_5();
            break;
        case 4:
            Problem3_4_5();
            break;
        case 5:
            Problem3_4_5();
            break;
        case 6:
            Problem6();
            break;
        case 7:
            Problem7();
            break;
        default:
            Console.WriteLine("Exiting the Lab 10...");
            loopBreak = false;
            break;
    }

    if (!loopBreak) break;
}

// Problem 1
void Problem1()
{
    Console.WriteLine("Problem 1");
    var fieldsInfo = new List<FieldInfo>();

    Console.WriteLine("Input your commands: (Type \"HARVEST\" to end the input)");
    var input = Console.ReadLine();
    while (!input.Equals("HARVEST"))
    {
        fieldsInfo.AddRange(GetCurrentFields(input));
        input = Console.ReadLine();
    }

    foreach (var fieldInfo in fieldsInfo)
    {
        Console.WriteLine($"{GetModifier(fieldInfo)} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
    }
}

// Problem 2
void Problem2()
{
    Console.WriteLine("Problem 2");

    var classType = typeof(BlackBoxInt);
    var methodsInfo = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
    var instance = (BlackBoxInt)Activator.CreateInstance(classType, true);

    Console.WriteLine("Input your command(Type \"END\" to exit): ");
    var input = Console.ReadLine();
    while (!input.Equals("END"))
    {
        var lineArgs = input.Split('_');
        var currentMethod = methodsInfo.FirstOrDefault(x => x.Name.Equals(lineArgs[0]));
        currentMethod.Invoke(instance, new object[] { int.Parse(lineArgs[1]) });

        var innerValue = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(x => x.Name.Equals("innerValue")).GetValue(instance);

        Console.WriteLine(innerValue);
        input = Console.ReadLine();
    }
}

// Problem 3 & 4 & 5
void Problem3_4_5()
{
    Console.WriteLine("Problem 3 & 4 & 5");

    IRepository repository = new UnitRepository();
    IUnitFactory unitFactory = new UnitFactory();
    IRunnable engine = new Engine(repository, unitFactory);
    engine.Run();
}

// Problem 6
void Problem6()
{
    Console.WriteLine("Problem 3 & 4");
    Console.WriteLine("Input traffic lights signal");
    IList<TrafficLightSignal> trafficLights = new List<TrafficLightSignal>();
    var input = Console.ReadLine().Split();

    foreach (string signal in input)
    {
        TrafficLightSignal currentTrafficLight;
        Enum.TryParse(signal, out currentTrafficLight);
        trafficLights.Add(currentTrafficLight);
    }

    var switchesCount = int.Parse(Console.ReadLine());

    var result = new StringBuilder();
    for (int i = 0; i < switchesCount; i++)
    {
        for (int j = 0; j < trafficLights.Count; j++)
        {
            var trafficLight = trafficLights[j];
            trafficLight = SwitchLight(trafficLight);
            trafficLights[j] = trafficLight;
            result.Append($"{trafficLight} ");
        }

        result.AppendLine();
    }

    Console.WriteLine(result.ToString().Trim());
}

// Problem 7
void Problem7()
{
    Console.WriteLine("Problem 7");

    ServiceProvider serviceProvider = GetServiceProvider();

    ICommandInterpreterProblem7 commandInterpreter = new CommandInterpreterProblem7(serviceProvider);
    var engine = new EngineProblem7(commandInterpreter);
    engine.Run();
}

#region Problem 1 Helper methods

string GetModifier(FieldInfo fieldInfo)
{
    if (fieldInfo.IsPublic)
    {
        return "public";
    }

    if (fieldInfo.IsPrivate)
    {
        return "private";
    }

    return "protected";
}

IEnumerable<FieldInfo> GetCurrentFields(string input)
{
    var type = Type.GetType("HarvestingFields");
    var fields =
        type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
    switch (input)
    {
        case "private":
            fields = fields.Where(x => x.IsPrivate).ToArray();
            break;
        case "protected":
            fields = fields.Where(x => x.IsFamily).ToArray();
            break;
        case "public":
            fields = fields.Where(x => x.IsPublic).ToArray();
            break;
    }

    return fields;
}

#endregion

#region Problem 6 Helper methods

TrafficLightSignal SwitchLight(TrafficLightSignal trafficLight)
{
    var enumLength = Enum.GetNames(typeof(TrafficLightSignal)).Length;
    var currentIndex = (int)trafficLight;
    trafficLight = (TrafficLightSignal)((currentIndex + 1) % enumLength);
    return trafficLight;
}

#endregion

#region Problem 7 Helper methods

ServiceProvider GetServiceProvider()
{
    var services = new ServiceCollection();

    services.AddSingleton<IWeaponRepository, WeaponRepository>();
    services.AddTransient<IWeaponFactory, WeaponFactory>();
    services.AddTransient<IGemFactory, GemFactory>();

    return services.BuildServiceProvider();
}

#endregion