using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SailPoint.Models.Dtos;
using SailPoint.Services;

namespace SailPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityDetailController : ControllerBase
    {
        private readonly ICityDetailService _cityDetailService;
        private readonly IMapper _mapper;

        public CityDetailController(ICityDetailService cityDetailService, IMapper mapper)
        {
            this._cityDetailService = cityDetailService;
            this._mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpPost]
        public async Task<AddCityDetailResponse> AddCity(AddCityDetailRequest request)
        {
            var dbEntity = await _cityDetailService.StoreCity(request);
            var response = _mapper.Map<AddCityDetailResponse>(dbEntity);
            return response;
        }
    }
}
