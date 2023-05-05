using Airline.Models;
using AutoMapper;
using Core.Models;
using Core.Models.AirlineService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Application.Profiles
{
    public class AirplaneProfile : Profile
    {
        public AirplaneProfile()
        {
            CreateMap<Aircraft, AircraftDto>();
        }
    }
}
