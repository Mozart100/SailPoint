using FluentAssertions;
using SailPoint.Models.Dtos;
using Xunit;

namespace SailPoint.Automation.Scenario;

/// <summarya
/// This class populate period type slots
/// </summary>
public class CitiesStaticDataScenario : ScenarioBase
{

    public CitiesStaticDataScenario(string baseUrl) : base(baseUrl)
    {
        AddCityUrl = $"{BaseUrl}/CityDetail";

        CitiesRequests = new List<AddCityDetailRequest>();

        Initialize_CityRequest();
    }

    public List<AddCityDetailRequest> CitiesRequests { get; }

    public string AddCityUrl { get; }

    public override string ScenarioName => "Populating static data.";

    public override string Description => "Populate static data regarding cities...";

    protected override async Task RunScenario()
    {
        await PopulateData();

    }

    private async Task PopulateData()
    {
        foreach (var request in CitiesRequests)
        {
            var response = await RunPostCommand<AddCityDetailRequest, AddCityDetailResponse>(AddCityUrl, request);

            response.Id.Should().BeGreaterThan(0);
            response.City.Should().Be(request.City);
        }
    }

    private void Initialize_CityRequest()
    {
        //   string[] countries = { "United States", "Canada", "United Kingdom", "Germany", "France", "Japan", "Australia", "Brazil", "India", "China" };
        //string[] cities = { "New York", "Toronto", "London", "Berlin", "Paris", "Tokyo", "Sydney", "Rio de Janeiro", "Mumbai", "Beijing" };
        string[] cities = {
            "Cairo", "Cape Town", "Caracas", "Casablanca", "Chennai", "Chicago", "Chittagong", "Cologne", "Copenhagen", "Cordoba",
            "Curitiba", "Cusco", "Cyberjaya", "Changchun", "Chengdu", "Chiba", "Chittorgarh", "Coimbatore", "Cali", "Canberra",
            "Copenhagen", "Cordoba", "Curitiba", "Cusco", "Cyberjaya", "Changchun", "Chengdu", "Chiba", "Chittorgarh", "Coimbatore", "Cali", "Canberra"
        };

        for (int i = 0; i < cities.Length; i++)
        {
            var cityDetail = new AddCityDetailRequest
            {
                City = cities[i]
            };

            CitiesRequests.Add(cityDetail);
        }
    }
}
