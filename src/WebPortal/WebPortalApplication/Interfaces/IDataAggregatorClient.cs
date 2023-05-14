using Airline.Application.Grpc;
using CarRent.Application.Grpc;
using Hotel.Application.Grpc;

namespace WebPortal.Application.Interfaces
{
    public interface IDataAggregatorClient
    {
        Task<IEnumerable<HotelData>> GetHotels(DateTime from, DateTime to, string country, string city, CancellationToken cancellationToken = default);
        Task<IEnumerable<CarData>> GetCars(DateTime from, DateTime to, string country, string city, string location, double latitude, double longitude, CancellationToken cancellationToken = default);
        Task<IEnumerable<FlightData>> GetFlights(DateTime from, DateTime to, string departureLocation, string arrivalLocation, CancellationToken cancellationToken = default);
    }
}
