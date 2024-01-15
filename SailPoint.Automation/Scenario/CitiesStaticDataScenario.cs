using FluentAssertions;
using SailPoint.Infrastracture;
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

        BusinessLogicLogicCallbacks.Add(PopulateData);
    }

    public List<AddCityRequest> CitiesRequests { get; }

    public override string ScenarioName => "Populating Database";

    public override string Description => "Populate static data regarding cities...";

    private async Task PopulateData()
    {
        foreach (var request in CitiesRequests)
        {
            var response = await RunPostCommand<AddCityRequest, AddCityResponse>(BaseUrl, request);

            response.Id.Should().BeGreaterThan(0);
            response.City.Should().Be(request.City);
        }

    }

    private void Initialize_CityRequest()
    {
        var cities = new List<string>();
        using (StreamReader reader = new StreamReader("world-cities.txt"))
        {
            // Read and discard the first line
            string firstLine = reader.ReadLine();

            // Read and process the remaining lines
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (!line.IsNullOrEmpty())

                {
                    cities.Add(line.Trim().ToLower());
                        }
            }
        }

        foreach (var city in cities)
        {
            var cityDetail = new AddCityRequest
            {
                City = city
            };

            CitiesRequests.Add(cityDetail);
        }
    }


    private void Initialize_CityRequest_Origin()
    {
        //string[] cities = { "New York", "Toronto", "London", "Berlin", "Paris", "Tokyo", "Sydney", "Rio de Janeiro", "Mumbai", "Beijing" };
        string[] cities = {
            "test","testt","testtt","testttt","testtttt",
             "New York", "Berlin", "Beijing", "Bangkok", "New Orlians", "Barcelona", "Brisbane", "Bucharest", "Budapest", "Baltimore", "Buenos Aires", "Busan",
            "Cairo", "Cape Town", "Caracas", "Casablanca", "Chennai", "Chicago", "Chittagong", "Cologne", "Copenhagen", "Cordoba",
            "Curitiba", "Cusco", "Cyberjaya", "Changchun", "Chengdu", "Chiba", "Chittorgarh", "Coimbatore", "Cali", "Canberra",
            "Copenhagen", "Cordoba", "Curitiba", "Cusco", "Cyberjaya", "Changchun", "Chengdu", "Chiba", "Chittorgarh", "Coimbatore", "Cali", "Canberra"
        };

        foreach (var city in cities)
        {
            var cityDetail = new AddCityRequest
            {
                City = city
            };

            CitiesRequests.Add(cityDetail);
        }
    }
}
