using CarRent.Models;

namespace CarRent.Application.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<IEnumerable<Car>> GetAllAsync(bool includeLocation = false, CancellationToken cancellationToken = default);
    }
}
