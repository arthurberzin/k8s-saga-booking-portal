using Microsoft.AspNetCore.Mvc;
using WebPortal.Application.Grpc;
using WebPortal.Application.Interfaces;
using static WebPortal.Application.Grpc.HotelService;

namespace WebPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {


        private readonly IHotelServiceClient _hotelServiceClient;

        public DataController(IHotelServiceClient hotelServiceClient)
        {
            _hotelServiceClient = hotelServiceClient;
        }

        [HttpGet]
        public async Task<IEnumerable<HotelData>> Get(CancellationToken cancellation)
        {
            return await _hotelServiceClient.GetHotels(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(100), cancellation);
        }
    }
}