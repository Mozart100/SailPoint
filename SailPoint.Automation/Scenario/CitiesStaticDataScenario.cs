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
        BatchUrl = $"{baseUrl}/batch";
        CitiesRequests = new List<AddBatchCityRequest>();

        Initialize_CityRequest();

        BusinessLogicLogicCallbacks.Add(PopulateData);
    }

    public List<AddBatchCityRequest> CitiesRequests { get; }

    public string BatchUrl { get; }

    public override string ScenarioName => "Populating Database";

    public override string Description => "Populate static data regarding cities...";

    private async Task PopulateData()
    {
        foreach (var request in CitiesRequests)
        {
            var response = await RunPostCommand<AddBatchCityRequest, AddBatchCityResponse>(BatchUrl, request);

            foreach (var cityResponse in response.AddCityResponsees)
            {
                cityResponse.Id.Should().BeGreaterThan(0);
            }
        }

    }

    private void Initialize_CityRequest()
    {
        var count = 1;
        var buffer = new List<string>();

        using (StreamReader reader = new StreamReader("world-cities.txt"))
        {
            //Skip Header.
            var firstLine = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (!line.IsNullOrEmpty())
                {
                    buffer.Add(line.Trim().ToLower());
                    if ((count % 40) == 0)
                    {
                        CitiesRequests.Add(new AddBatchCityRequest { Cities = buffer.ToArray() });
                        count = 1;
                        buffer.Clear();
                    }
                    else
                    {
                        count++;
                    }
                }
            }
        }
    }


    //private void Initialize_CityRequest()
    //{
    //    //string[] cities = { "New York", "Toronto", "London", "Berlin", "Paris", "Tokyo", "Sydney", "Rio de Janeiro", "Mumbai", "Beijing" };
    //    string[] cities = {
    //        "test","testt","testtt","testttt","testtttt",
    //         "New York", "Berlin", "Beijing", "Bangkok", "New Orlians", "Barcelona", "Brisbane", "Bucharest", "Budapest", "Baltimore", "Buenos Aires", "Busan",
    //        "Cairo", "Cape Town", "Caracas", "Casablanca", "Chennai", "Chicago", "Chittagong", "Cologne", "Copenhagen", "Cordoba",
    //        "Curitiba", "Cusco", "Cyberjaya", "Changchun", "Chengdu", "Chiba", "Chittorgarh", "Coimbatore", "Cali", "Canberra",
    //        "Copenhagen", "Cordoba", "Curitiba", "Cusco", "Cyberjaya", "Changchun", "Chengdu", "Chiba", "Chittorgarh", "Coimbatore", "Cali", "Canberra"
    //    };
    //    CitiesRequests.Add(new AddBatchCityRequest { Cities = cities });


    //}
}
