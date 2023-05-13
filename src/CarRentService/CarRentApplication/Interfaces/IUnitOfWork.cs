using CarRent.Models;

namespace CarRent.Application.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        ICarOccupiedDateRepository OccupiedDates { get; }
        ICarRepository Cars { get; }
        ILocationRepository Locations { get; }
        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
