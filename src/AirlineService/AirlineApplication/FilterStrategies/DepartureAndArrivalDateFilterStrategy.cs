using Airline.Application.Grpc;
using Airline.Models;
using Airline.Application.Interfaces;
using System.Linq.Expressions;

namespace Airline.Application.FilterStrategies
{
    public class DepartureAndArrivalDateFilterStrategy : IFlightFilterStrategy
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartureAndArrivalDateFilterStrategy(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Flight>> FilterFlightsAsync(FlightsRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Flights.FindAsync(IsFlightMatch(request), cancellationToken);
        }


        public Expression<Func<Flight, bool>> IsFlightMatch(FlightsRequest request)
        {
            return flight => flight.DepartureAirport.City.ToLower() == request.DepartureLocation.ToLower()
                    && flight.ArrivalAirport.City.ToLower() == request.ArrivalLocation.ToLower()
                    && flight.DepartureDateTime >= request.From.ToDateTime()
                    && flight.ArrivalDateTime <= request.To.ToDateTime();
        }
    }

}
