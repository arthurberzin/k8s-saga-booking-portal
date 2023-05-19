using Booking.Models;

namespace Booking.Application.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICarBookingRepository CarBookings { get; }
        IFlightBookingRepository FlightBookings { get; }
        IHotelBookingRepository HotelBookings { get; }
        int Complete();
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
