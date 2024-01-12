using AutoMapper;
using NetBet.Services.Validations;
using SailPoint.DataAccess.Models;
using SailPoint.DataAccess.Repository;
using SailPoint.Models;
using SailPoint.Models.Dtos;

namespace SailPoint.Services
{

    public interface ICityDetailService
    {
        Task<CityDetailDb> StoreCity(AddCityDetailRequest request);
    }

    public class CityDetailService : ICityDetailService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly ICityValidationService _cityValidationService;

        public CityDetailService(ICityRepository cityRepository, IMapper mapper,ICityValidationService cityValidationService)
        {
            this._cityRepository = cityRepository;
            this._mapper = mapper;
            this._cityValidationService = cityValidationService;
        }

        public async Task<CityDetailDb> StoreCity(AddCityDetailRequest request)
        {
            var city = _mapper.Map<CityDetailDb>(request);
            var cityDetailDb  = await _cityRepository.InsertAsync(city);

            return cityDetailDb;
        }
    }
}
