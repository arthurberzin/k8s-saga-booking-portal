using WebPortal.Application.Interfaces;
using WebPortal.Models;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Serilog;
using CarRent.Application.Grpc;
using Hotel.Application.Grpc;
using Airline.Application.Grpc;

namespace WebPortal.Application.Grpc
{
    public class DataAggregatorClient : IDataAggregatorClient
    {
        private IOptions<WebPortalOptions> _options;
        private readonly ILogger _logger;
        public DataAggregatorClient(IOptions<WebPortalOptions> options, ILogger logger) 
        {
            _options = options;
            _logger = logger;
        }
        public async Task<IEnumerable<FlightData>> GetFlights(DateTime from, DateTime to, string departureLocation, string arrivalLocation, CancellationToken cancellationToken = default)
        {
            try
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);


                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;


                var channel = GrpcChannel.ForAddress(_options.Value.AirlinesServiceUrl,
                    new GrpcChannelOptions { HttpHandler = handler });
                var client = new FlightsService.FlightsServiceClient(channel);
                var request = new FlightsRequest
                {
                    DepartureLocation = departureLocation, //Warsaw
                    ArrivalLocation = arrivalLocation, //Napoli
                    From = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(from),
                    To = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(to)
                };

                var reply = await client.GetFlightsAsync(request, cancellationToken: cancellationToken);
                return reply.Flights;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return Enumerable.Empty<FlightData>();
            }
        }

        public async Task<IEnumerable<HotelData>> GetHotels(DateTime from, DateTime to, string country, string city, CancellationToken cancellationToken = default)
        {
            try
            {
                var channel = GrpcChannel.ForAddress(_options.Value.HotelServiceUrl);
                var client = new HotelService.HotelServiceClient(channel);
                var request = new HotelsRequest
                {
                    Country = country,//"Italy"
                    City = city, // "Amalfi"
                    From = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(from),
                    To = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(to)
                };

                var reply = await client.GetHotelsAsync(request, cancellationToken: cancellationToken);
                return reply.Hotels;
            }
            catch(Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return Enumerable.Empty<HotelData>();
            }
        }
        public async Task<IEnumerable<CarData>> GetCars(DateTime from, DateTime to, string country, string city, string location, double latitude, double longitude, CancellationToken cancellationToken = default)
        {
            try
            {
                var channel = GrpcChannel.ForAddress(_options.Value.CarRentServiceUrl);
                var client = new CarService.CarServiceClient(channel);
                var request = new CarsRequest
                {
                    Country = country,//"Italy"
                    City = city,// "Napoli"
                    Location = location, // "Naples International Airport"
                    Latitude = latitude, 
                    Longitude = longitude,
                    From = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(from),
                    To = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(to)
                };

                var reply = await client.GetCarsAsync(request, cancellationToken: cancellationToken);
                return reply.Cars;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return Enumerable.Empty<CarData>();
            }
        }
    }
}
