using AutoMapper;
using CarRent.Application.Interfaces;
using CarRent.Models;
using Core.Models;

namespace CarRent.Application.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>().ForMember(dest => dest.Distance, opt => opt.Ignore() );
        }
    }
}
