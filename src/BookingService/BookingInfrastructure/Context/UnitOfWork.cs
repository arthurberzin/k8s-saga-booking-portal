using Booking.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context,
            IUserRepository userRepository,
            ICarBookingRepository carBookingRepository,
            IFlightBookingRepository flightBookingRepository,
            IHotelBookingRepository hotelBookingRepository)
        {
            _context = context;
            Users = userRepository;
            CarBookings = carBookingRepository;
            FlightBookings = flightBookingRepository;
            HotelBookings = hotelBookingRepository;
        }

        public IUserRepository Users { get; private set; }
        public ICarBookingRepository CarBookings { get; private set; }
        public IFlightBookingRepository FlightBookings { get; private set; }
        public IHotelBookingRepository HotelBookings { get; private set; }

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
