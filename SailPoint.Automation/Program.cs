using SailPoint.Automation.Scenario;

var baseUrl = "https://localhost:7138";


var staticDataScenario = new CitiesStaticDataScenario(baseUrl);
await staticDataScenario.StartRunScenario();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();



Console.WriteLine("All test passed successfully!!!!!");
Console.WriteLine("All test passed successfully!!!!!");
Console.WriteLine("All test passed successfully!!!!!");
Console.WriteLine("All test passed successfully!!!!!");
Console.WriteLine("All test passed successfully!!!!!");
Console.WriteLine("All test passed successfully!!!!!");


Console.ReadLine();

