using Airline.Application.Grpc;
using Airline.Models;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace Airline.Application.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightData>()
                .ForMember(dest => dest.FlightDuration, opt => opt.MapFrom(src => src.ArrivalDateTime - src.DepartureDateTime))
                .ForMember(dest => dest.AircraftNumber, opt => opt.MapFrom(src => src.Aircraft.RegistrationNumber))
                .ForMember(dest => dest.AircraftCapacity, opt => opt.MapFrom(src => src.Aircraft.Capacity))
                .ForMember(dest => dest.AircraftType, opt => opt.MapFrom(src => src.Aircraft.AircraftType))
                .ForMember(dest => dest.AircraftOccupiedCapacity, opt => opt.MapFrom(src => src.SeatsBookings.Count))
                .ForMember(dest => dest.ArrivalAirport, opt => opt.MapFrom(src => src.ArrivalAirport.AirportCode))
                .ForMember(dest => dest.ArrivalAirportCity, opt => opt.MapFrom(src => src.ArrivalAirport.City))
                .ForMember(dest => dest.ArrivalAirportCountry, opt => opt.MapFrom(src => src.ArrivalAirport.Country))
                .ForMember(dest => dest.DepartureAirport, opt => opt.MapFrom(src => src.DepartureAirport.AirportCode))
                .ForMember(dest => dest.DepartureAirportCity, opt => opt.MapFrom(src => src.DepartureAirport.City))
                .ForMember(dest => dest.DepartureAirportCountry, opt => opt.MapFrom(src => src.DepartureAirport.Country))
                .ForMember(dest => dest.FlightDuration, opt => opt.MapFrom(src => Duration.FromTimeSpan(src.ArrivalDateTime.ToUniversalTime() - src.DepartureDateTime.ToUniversalTime())))
                .ForMember(dest => dest.ArrivalDateTime, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.ArrivalDateTime.ToUniversalTime())))
                .ForMember(dest => dest.DepartureDateTime, opt => opt.MapFrom(src => Timestamp.FromDateTime(src.DepartureDateTime.ToUniversalTime())));


        }
    }
}

