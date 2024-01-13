using AutoMapper;
using SailPoint.DataAccess.Models;
using SailPoint.Models.Dtos;

namespace NetBet.Startup;

public class ConfigureMapper : Profile
{
    public ConfigureMapper()
    {
        CreateMap<AddCityRequest, CityDb>();
        CreateMap<CityDb, AddCityResponse>();
    }
}
