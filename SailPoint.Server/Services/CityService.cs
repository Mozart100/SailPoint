using AutoMapper;
using SailPoint.DataAccess.Models;
using SailPoint.DataAccess.Repository;
using SailPoint.Models.Dtos;
using SailPoint.Services.Validations;

namespace SailPoint.Services;


public interface ICityService
{
    Task<CityDb> StoreCityAsync(AddCityRequest request);
}

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    private readonly ICityValidationService _cityValidationService;
    private readonly ICityLocaterService _cityLocaterService;

    public CityService(ICityRepository cityRepository, IMapper mapper,
        ICityValidationService cityValidationService,
        ICityLocaterService cityLocaterService
        )
    {
        this._cityRepository = cityRepository;
        this._mapper = mapper;
        this._cityValidationService = cityValidationService;
        this._cityLocaterService = cityLocaterService;
    }

    public async Task<CityDb> StoreCityAsync(AddCityRequest request)
    {
        await _cityValidationService.AddCarRequestValidateAsync(request);

        var city = _mapper.Map<CityDb>(request);
        var cityDetailDb = await _cityRepository.InsertAsync(city);
        await _cityLocaterService.StoreCityAsync(cityDetailDb.City);

        return cityDetailDb;
    }
}
