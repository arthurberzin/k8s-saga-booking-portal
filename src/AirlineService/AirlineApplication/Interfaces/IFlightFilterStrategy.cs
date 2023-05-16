using Airline.Application.Grpc;
using Airline.Models;
using System.Linq.Expressions;

namespace Airline.Application.Interfaces
{
    public  interface IFlightFilterStrategy
    {
        Task<IEnumerable<Flight>> FilterFlightsAsync(FlightsRequest request, CancellationToken cancellationToken);

        Expression<Func<Flight, bool>> IsFlightMatch(FlightsRequest request);
    }
}
