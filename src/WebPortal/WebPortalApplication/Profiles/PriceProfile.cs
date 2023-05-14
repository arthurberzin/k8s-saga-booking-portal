using AutoMapper;
using Hotel.Application.Grpc;
using WebPortal.Application.Dto;

namespace WebPortal.Application
{
    public  class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<PriceDetails,PriceDto>();
        }
    }
}
