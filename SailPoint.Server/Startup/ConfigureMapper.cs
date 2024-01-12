using AutoMapper;
using SailPoint.DataAccess.Models;
using SailPoint.Models.Dtos;

namespace NetBet.Startup;

public class ConfigureMapper : Profile
{
    public ConfigureMapper()
    {
        CreateMap<AddCityDetailRequest, CityDetailDb>();
        CreateMap<CityDetailDb, AddCityDetailResponse>();

        //CreateMap<Car, AddCarResponse>().ForMember(des => des.CarId, op => op.MapFrom(src => src.Id));
        //CreateMap<Car, CarItem>();
        //CreateMap<Car, GetCarQueryResponse>();





        ////CreateMap<NetBetException, AddCarResponse>();

        //CreateMap<CarRentalRequest, RentDetails>();
        //CreateMap<RentDetails, CarRentalResponse>().
        //    ForMember(des => des.RentId, op => op.MapFrom(src => src.Id));


        //CreateMap<RentDetails, CarRentalItem>()
        //    .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.From.ToShortDateString()))
        //    .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.To.ToShortDateString()));
    }
}
