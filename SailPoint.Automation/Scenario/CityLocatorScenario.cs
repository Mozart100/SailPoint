﻿using FluentAssertions;
using SailPoint.Infrastracture;
using SailPoint.Models.Dtos;

namespace SailPoint.Automation.Scenario;

public class CityLocatorScenario : ScenarioBase
{

    public CityLocatorScenario(string baseUrl) : base(baseUrl)
    {
        GetCitiesUrl = $"{BaseUrl}/cities";
    }

    public string GetCitiesUrl { get; }

    public override string ScenarioName => "City locator scenario";

    public override string Description => "Integration tests for CityLocatorService";

    protected override async Task RunScenario()
    {
        await SanityTest_Expect_2_Records();
    }

    private async Task SanityTest_Expect_2_Records()
    {
        var response = await Get<GetCitiesResponse>($"{GetCitiesUrl}/new");
        response.Cities.SafeCount().Should().Be(2);

    }
}