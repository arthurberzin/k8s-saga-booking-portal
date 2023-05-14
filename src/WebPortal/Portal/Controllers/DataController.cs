using Airline.Application.Grpc;
using AutoMapper;
using CarRent.Application.Grpc;
using Hotel.Application.Grpc;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Application.Dto;
using WebPortal.Application.Grpc;
using WebPortal.Application.Interfaces;

namespace WebPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {


        private readonly IDataAggregatorClient _dataClient;
        private readonly IMapper _mapper;

        public DataController(IDataAggregatorClient hotelServiceClient, IMapper mapper)
        {
            _dataClient = hotelServiceClient;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("hotels")]
        public async Task<IEnumerable<HotelDto>> GetHotels(CancellationToken cancellation)
        {
            var result = await _dataClient.GetHotels(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(6), "Italy", "Amalfi", cancellation);
            return _mapper.Map<List<HotelDto>>(result);
        }
        [HttpGet]
        [Route("rentcars")]
        public async Task<IEnumerable<CarDto>> GetCars(CancellationToken cancellation)
        {
            var result = await _dataClient.GetCars(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(7), "Italy", "Napoli", "Naples International Airport",0,0, cancellation);
            return _mapper.Map<List<CarDto>>(result);
        }
        [HttpGet]
        [Route("flights")]
        public async Task<IEnumerable<FlightDto>> GetFlights(CancellationToken cancellation)
        {
            var result = await _dataClient.GetFlights(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(100), "Warsaw", "Napoli", cancellation);
            return _mapper.Map<List<FlightDto>>(result);
        }
    }
}