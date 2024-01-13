using AutoMapper;
using SailPoint.DataAccess.Models;
using SailPoint.Models.Dtos;

namespace NetBet.Startup;

public class ConfigureMapper : Profile
{
    public ConfigureMapper()
    {
        CreateMap<AddCityDetailRequest, CityDb>();
        CreateMap<CityDb, AddCityDetailResponse>();
    }
}
