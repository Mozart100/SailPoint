using AutoMapper;
using SailPoint.DataAccess.Models;
using SailPoint.DataAccess.Repository;
using SailPoint.Models.Dtos;
using SailPoint.Services.Validations;

namespace SailPoint.Services;


public interface ICityDetailService
{
    Task<CityDetailDb> StoreCityAsync(AddCityDetailRequest request);
}

public class CityDetailService : ICityDetailService
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;
    private readonly ICityValidationService _cityValidationService;
    private readonly ICityLocaterService _cityLocaterService;

    public CityDetailService(ICityRepository cityRepository, IMapper mapper,
        ICityValidationService cityValidationService,
        ICityLocaterService cityLocaterService
        )
    {
        this._cityRepository = cityRepository;
        this._mapper = mapper;
        this._cityValidationService = cityValidationService;
        this._cityLocaterService = cityLocaterService;
    }

    public async Task<CityDetailDb> StoreCityAsync(AddCityDetailRequest request)
    {
        var city = _mapper.Map<CityDetailDb>(request);
        var cityDetailDb = await _cityRepository.InsertAsync(city);
        await _cityLocaterService.StoreCityAsync(cityDetailDb.City);

        return cityDetailDb;
    }
}
