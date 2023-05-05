using AutoMapper;
using Core.Models;
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application
{
    public  class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<PeriodPrice, PriceDto>();
        }
    }
}
