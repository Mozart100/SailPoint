using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SailPoint.Infrastracture;
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
    [Route("cities/{prefix}")]
<<<<<<< HEAD
    public async Task<GetCitiesResponse> GetAllCitities(string prefix)
    {
        if (prefix.IsNullOrEmpty())
        {
            var error = new SailPointError("predix", "Shouldnt be empty");
            throw new SailPointException(new[] { error });
        }

        var cities = await _cityLocaterService.SearchCitiesAsync(prefix);
        return new GetCitiesResponse { Cities = cities.ToArray() };
=======
    public async Task<GetCitiesResponse> AddCity(GetCitiesRequest request)
    {
        //_cityLocaterService.SearchCitiesAsync()
        return null;
>>>>>>> 0b7b8d59cb5fdab65559c7a8522d0dcc8fc2566a
    }
}
