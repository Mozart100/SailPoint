using FluentAssertions;
using SailPoint.Models.Dtos;
<<<<<<< HEAD
=======
using System.Reflection;
using Xunit;
>>>>>>> 0b7b8d59cb5fdab65559c7a8522d0dcc8fc2566a

namespace SailPoint.Automation.Scenario;

/// <summarya
/// This class populate period type slots
/// </summary>
public class CitiesStaticDataScenario : ScenarioBase
{

    public CitiesStaticDataScenario(string baseUrl) : base(baseUrl)
    {
        //AddCityUrl = $"{BaseUrl}/CityDetail";

        CitiesRequests = new List<AddCityDetailRequest>();

        Initialize_CityRequest();
    }

    public List<AddCityDetailRequest> CitiesRequests { get; }

    //public string AddCityUrl { get; }

    public override string ScenarioName => "Populating static data.";

    public override string Description => "Populate static data regarding cities...";

    protected override async Task RunScenario()
    {
        //await CallbackWrapper(async () =>);

        await PopulateData();

    }

    //public async Task CallbackWrapper(Func<Task> callback)
    //{
    //    var methodName = GetMethodName(callback);
    //    await callback();
    //}
    //private string GetMethodName(Delegate callback)
    //{
    //    if (callback == null)
    //        throw new ArgumentNullException(nameof(callback));

    //    MethodInfo methodInfo = callback.Method;
    //    return methodInfo.Name;
    //}
    private async Task PopulateData()
    {
        Console.WriteLine($"{nameof(PopulateData)} Started.");

        foreach (var request in CitiesRequests)
        {
            var response = await RunPostCommand<AddCityDetailRequest, AddCityDetailResponse>(BaseUrl, request);

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
             "New York", "Berlin", "Beijing", "Bangkok", "New Orlians", "Barcelona", "Brisbane", "Bucharest", "Budapest", "Baltimore", "Buenos Aires", "Busan",
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
