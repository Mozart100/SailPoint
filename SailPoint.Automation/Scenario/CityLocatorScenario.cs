using FluentAssertions;
using SailPoint.Infrastracture;
using SailPoint.Models.Dtos;

namespace SailPoint.Automation.Scenario;

public class CityLocatorScenario : ScenarioBase
{

    public CityLocatorScenario(string baseUrl) : base(baseUrl)
    {
        //GetCitiesUrl = $"{BaseUrl}";

        BusinessLogicCallback.Add(SanityTest_Expect_5_Records);
        BusinessLogicCallback.Add(SanityTest_Expect_2_Records);

        //Runner.Calls.Add(async ()>await Method1())
        //Runner.Calls.Add(async ()>await Method2())
    }

    public override string ScenarioName => "City locator scenario";
    public override string Description => "Integration tests for CityLocatorService";

    private async Task SanityTest_Expect_5_Records()
    {
        var response = await Get<GetCitiesResponse>($"{BaseUrl}/tes/level/10");
        response.Cities.SafeCount().Should().Be(5);
    }

    private async Task SanityTest_Expect_2_Records()
    {
        var response = await Get<GetCitiesResponse>($"{BaseUrl}/tes/level/2");
        response.Cities.SafeCount().Should().Be(2);
    }
}
