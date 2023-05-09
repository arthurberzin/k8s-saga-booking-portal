using Airline.Application.Interfaces;
using Airline.Models;
using Microsoft.EntityFrameworkCore;

namespace Airline.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context,
            IAircraftRepository airplaneRepository,
            IAirportRepository airportRepository,
            IBookingRepository bookingRepository,
            ICrewRepository crewRepository,
            IEmployeePositionRepository employeePositionRepository,
            IEmployeeRepository employeeRepository,
            IFlightRepository flightRepository,
            ISeatRepository seats)
        {
            _context = context;
            Aircrafts = airplaneRepository;
            Airports = airportRepository;
            Bookings = bookingRepository;
            Crews = crewRepository;
            EmployeePositions = employeePositionRepository;
            Employees = employeeRepository;
            Flights = flightRepository;
            Seats = seats;
        }

        public IAircraftRepository Aircrafts { get; private set; }
        public IAirportRepository Airports { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public ICrewRepository Crews { get; private set; }
        public IEmployeePositionRepository EmployeePositions { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IFlightRepository Flights { get; private set; }
        public ISeatRepository Seats { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
