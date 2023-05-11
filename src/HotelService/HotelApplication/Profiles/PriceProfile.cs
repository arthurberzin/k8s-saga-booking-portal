using AutoMapper;
using Hotel.Application.Grpc;
using Hotel.Models;

namespace Hotel.Application
{
    public  class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<PeriodPrice, PriceDetails>();
        }
    }
}
