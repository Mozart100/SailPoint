using FluentAssertions;
using SailPoint.Infrastracture;
using SailPoint.Models.Dtos;

namespace SailPoint.Automation.Scenario;

public class CityLocatorScenario : ScenarioBase
{

    public CityLocatorScenario(string baseUrl) : base(baseUrl)
    {
        BusinessLogicLogicCallbacks.Add(SanityTest_Expect_5_Records);
        BusinessLogicLogicCallbacks.Add(SanityTest_Expect_2_Records);
    }

    public override string ScenarioName => "City Locator";
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
