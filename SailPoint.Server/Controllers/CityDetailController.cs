using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SailPoint.Models.Dtos;
using SailPoint.Services;
using SailPoint.Services.Validations;

namespace SailPoint.Controllers;

[ApiController]
[Route("[controller]")]
public class CityDetailController : ControllerBase
{
    private readonly ICityDetailService _cityDetailService;
    private readonly ICityLocaterService _cityLocaterService;
    private readonly IMapper _mapper;

    public CityDetailController(ICityDetailService cityDetailService, ICityLocaterService cityLocaterService, IMapper mapper)
    {
        this._cityDetailService = cityDetailService;
        this._cityLocaterService = cityLocaterService;
        this._mapper = mapper;
    }

    [HttpPost]
    public async Task<AddCityDetailResponse> AddCity(AddCityDetailRequest request)
    {
        var dbEntity = await _cityDetailService.StoreCityAsync(request);
        var response = _mapper.Map<AddCityDetailResponse>(dbEntity);
        return response;
    }


    [HttpGet]
    [Route("cities/")]
    public async Task<GetCitiesResponse> GetAllCitities()
    {
        var cities = await _cityLocaterService.GetAllCitiesAsync();
        return new GetCitiesResponse { Cities = cities.ToArray() };
    }

    [HttpGet]
    [Route("cities/{prefix}/level/{level}")]
    public async Task<GetCitiesResponse> GetCitities(string prefix, int level)
    {
        if (level <= 0)
        {
            var error = new SailPointError("level", "Should be above zero.");
            throw new SailPointException(new[] { error });
        }

        var cities = await _cityLocaterService.SearchCitiesAsync(prefix, level);
        return new GetCitiesResponse { Cities = cities.ToArray() };
    }
}
