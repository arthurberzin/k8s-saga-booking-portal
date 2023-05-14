using Airline.Application.Grpc;
using AutoMapper;
using CarRent.Application.Grpc;
using WebPortal.Application.Dto;


namespace WebPortal.Application
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {                     
            CreateMap<FlightData, FlightDto>()
                .ForMember(dest => dest.DepartureDateTime, opt => opt.MapFrom(src => src.DepartureDateTime.ToDateTime()))
                .ForMember(dest => dest.ArrivalDateTime, opt => opt.MapFrom(src => src.ArrivalDateTime.ToDateTime()))
                .ForMember(dest => dest.FlightDuration, opt => opt.MapFrom(src => src.FlightDuration.ToTimeSpan()));
        }
    }
}
