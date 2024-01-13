using FluentAssertions;
using SailPoint.Models.Dtos;

namespace SailPoint.Automation.Scenario;

/// <summarya
/// This class populate period type slots
/// </summary>
public class CitiesStaticDataScenario : ScenarioBase
{

    public CitiesStaticDataScenario(string baseUrl) : base(baseUrl)
    {
        CitiesRequests = new List<AddCityRequest>();

        Initialize_CityRequest();
    }

    public List<AddCityRequest> CitiesRequests { get; }

    public override string ScenarioName => "Populating static data.";

    public override string Description => "Populate static data regarding cities...";

    protected override async Task RunScenario()
    {
        await PopulateData();
    }

    private async Task PopulateData()
    {
        Console.WriteLine($"{nameof(PopulateData)} Started.");

        foreach (var request in CitiesRequests)
        {
            var response = await RunPostCommand<AddCityRequest, AddCityResponse>(BaseUrl, request);

            response.Id.Should().BeGreaterThan(0);
            response.City.Should().Be(request.City);
        }

        Console.WriteLine($"{nameof(PopulateData)} Finished.");
        Console.WriteLine();
        Console.WriteLine("-------------------------------------------------------------------------------------------------");
        Console.WriteLine("-------------------------------------------------------------------------------------------------");

    }

    private void Initialize_CityRequest()
    {
        //string[] cities = { "New York", "Toronto", "London", "Berlin", "Paris", "Tokyo", "Sydney", "Rio de Janeiro", "Mumbai", "Beijing" };
        string[] cities = {
            "test","testt","testtt","testttt","testtttt",
             "New York", "Berlin", "Beijing", "Bangkok", "New Orlians", "Barcelona", "Brisbane", "Bucharest", "Budapest", "Baltimore", "Buenos Aires", "Busan",
            "Cairo", "Cape Town", "Caracas", "Casablanca", "Chennai", "Chicago", "Chittagong", "Cologne", "Copenhagen", "Cordoba",
            "Curitiba", "Cusco", "Cyberjaya", "Changchun", "Chengdu", "Chiba", "Chittorgarh", "Coimbatore", "Cali", "Canberra",
            "Copenhagen", "Cordoba", "Curitiba", "Cusco", "Cyberjaya", "Changchun", "Chengdu", "Chiba", "Chittorgarh", "Coimbatore", "Cali", "Canberra"
        };

        foreach(var city in cities)
        {
            var cityDetail = new AddCityRequest
            {
                City = city
            };

            CitiesRequests.Add(cityDetail);
        }
    }
}
