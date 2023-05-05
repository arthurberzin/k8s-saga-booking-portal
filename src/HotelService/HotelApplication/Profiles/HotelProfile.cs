using AutoMapper;
using Core.Models;
using Hotel.Models;

namespace Hotel.Application
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
                     
            CreateMap<HotelData, HotelDto>()
                .ForMember(dest => dest.OccupateDates, opt => opt.MapFrom(src => src.OccupateDates.Select(it=>it.DayOfYear).ToArray()))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(it => it.ImageUrl).ToArray()));
        }
    }
}
