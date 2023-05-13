using Airline.Application.Grpc;
using CarRent.Application.Grpc;
using Hotel.Application.Grpc;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Application.Grpc;
using WebPortal.Application.Interfaces;

namespace WebPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {


        private readonly IDataAggregatorClient _dataClient;

        public DataController(IDataAggregatorClient hotelServiceClient)
        {
            _dataClient = hotelServiceClient;
        }

        [HttpGet]
        [Route("hotels")]
        public async Task<IEnumerable<HotelData>> GetHotels(CancellationToken cancellation)
        {
            return await _dataClient.GetHotels(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(100), "Italy", "Amalfy", cancellation);
        }
        [HttpGet]
        [Route("rentcars")]
        public async Task<IEnumerable<CarData>> GetCars(CancellationToken cancellation)
        {
            return await _dataClient.GetCars(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(100), "Naples International Airport", cancellation);
        }
        [HttpGet]
        [Route("flights")]
        public async Task<IEnumerable<FlightData>> GetFlights(CancellationToken cancellation)
        {
            return await _dataClient.GetFlights(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(100), "Warsaw", "Napoli", cancellation);
        }
    }
}