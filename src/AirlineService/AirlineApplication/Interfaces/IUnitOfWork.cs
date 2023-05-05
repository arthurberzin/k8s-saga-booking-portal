namespace Airline.Application.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        IAircraftAssignmentRepository AircraftAssignments { get; }
        IAircraftRepository Aircrafts { get; }
        IAirportRepository Airports { get; }
        IBookingRepository Bookings { get; }
        ICrewRepository Crews { get; }
        IEmployeePositionRepository EmployeePositions { get; }
        IEmployeeRepository Employees { get; }
        IFlightRepository Flights { get; }

        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
