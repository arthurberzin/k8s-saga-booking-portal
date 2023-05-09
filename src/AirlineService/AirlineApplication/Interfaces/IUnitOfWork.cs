namespace Airline.Application.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        IAircraftRepository Aircrafts { get; }
        IAirportRepository Airports { get; }
        IBookingRepository Bookings { get; }
        ICrewRepository Crews { get; }
        IEmployeePositionRepository EmployeePositions { get; }
        IEmployeeRepository Employees { get; }
        IFlightRepository Flights { get; }
        ISeatRepository Seats { get; }

        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
