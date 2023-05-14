using AutoMapper;
using Core.Models;
using Google.Protobuf.WellKnownTypes;
using Hotel.Application.Grpc;
using Hotel.Models;

namespace Hotel.Application
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
                     
            CreateMap<Hotel.Models.HotelData, Hotel.Application.Grpc.HotelData>()
                .ForMember(dest => dest.OccupiedDates, opt => opt.MapFrom(src => src.OccupiedDates.Select(it=> Timestamp.FromDateTime(it.OccupateDate)).ToArray()))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(it => it.ImageUrl).ToArray()));
        }
    }
}
