namespace SailPoint.Services;

public interface ICityLocaterService
{
    Task<IEnumerable<string>> SearchCitiesAsync(string prefix);
    Task StoreCityAsync(string city);
}

public class CityLocaterService : ICityLocaterService
{
    private readonly GraphCities _graphCity;

    public CityLocaterService()
    {
        _graphCity = new GraphCities();
    }

    public async Task StoreCityAsync(string city)
    {
        _graphCity.InsertCity(city);
    }

    public async Task<IEnumerable<string>> SearchCitiesAsync(string prefix)
    {
        var cities = _graphCity.SearchCities(prefix);
        return cities;
    }
}
