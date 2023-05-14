using AutoMapper;
using CarRent.Application.Grpc;
using CarRent.Models;
using Google.Protobuf.WellKnownTypes;
using System;

namespace CarRent.Application.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarData>()
                .ForMember(dest => dest.Distance, opt => opt.Ignore() )
                .ForMember(dest => dest.OccupiedDates, opt => opt.MapFrom( src => src.OccupiedDates.Select(it=> Timestamp.FromDateTime(it.OccupateDate)).ToList()));
        }
    }
}
