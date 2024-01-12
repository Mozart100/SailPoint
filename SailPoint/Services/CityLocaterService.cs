namespace SailPoint.Services;

public interface ICityLocaterService
{
    Task<IEnumerable<string>> SearchCitiesAsync(string prefix);
    Task<bool> StoreCityAsync(string city);
}

public class CityLocaterService : ICityLocaterService
{
    private readonly GraphCities _graphCity;

    public CityLocaterService()
    {
        _graphCity = new GraphCities();
    }

    public async Task<bool> StoreCityAsync(string city)
    {
        _graphCity.InsertCity(city);

        return true;
    }

    public async Task<IEnumerable<string>> SearchCitiesAsync(string prefix)
    {
        var cities = _graphCity.SearchCities(prefix);
        return cities;
    }
}
