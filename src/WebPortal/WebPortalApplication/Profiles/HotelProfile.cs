using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using WebPortal.Application.Dto;


namespace WebPortal.Application
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {                     
            CreateMap<Hotel.Application.Grpc.HotelData,HotelDto>()
                .ForMember(dest => dest.OccupiedDates, opt => opt.MapFrom(src => src.OccupiedDates.Select(it=> it.ToDateTime()).ToArray()));
        }
    }
}
