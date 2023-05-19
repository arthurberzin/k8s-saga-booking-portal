using Booking.Models;

namespace Booking.Application.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
