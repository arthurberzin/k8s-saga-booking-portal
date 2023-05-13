using AutoMapper;
using CarRent.Application.Grpc;
using CarRent.Models;

namespace CarRent.Application.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarData>()
                .ForMember(dest => dest.Distance, opt => opt.Ignore() )
                .ForMember(dest => dest.OccupiedDates, opt => opt.MapFrom( src => src.OccupiedDates.Select(it=>it.DayOfYear).ToList()));
        }
    }
}
