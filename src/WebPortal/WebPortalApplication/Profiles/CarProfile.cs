using AutoMapper;
using CarRent.Application.Grpc;
using WebPortal.Application.Dto;


namespace WebPortal.Application
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {                     
            CreateMap<CarData,CarDto>()
                .ForMember(dest => dest.OccupiedDates, opt => opt.MapFrom(src => src.OccupiedDates.Select(it=> it.ToDateTime()).ToArray()));
        }
    }
}
