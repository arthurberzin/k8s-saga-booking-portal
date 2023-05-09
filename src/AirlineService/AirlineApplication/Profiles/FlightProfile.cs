using Airline.Models;
using AutoMapper;
using Core.Models;
using Core.Models.AirlineService;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDto>()
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
                .ForMember(dest => dest.DepartureAirportCountry, opt => opt.MapFrom(src => src.DepartureAirport.Country));            
        }
    }
}

