using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SailPoint.Models.Dtos;
using SailPoint.Services;

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
    public async Task<GetCitiesResponse> AddCity(GetCitiesRequest request)
    {
        //_cityLocaterService.SearchCitiesAsync()
        return null;
    }
}
