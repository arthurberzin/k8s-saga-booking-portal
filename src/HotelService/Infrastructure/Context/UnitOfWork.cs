using Hotel.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context,
            IHotelRepository hotelsRepository,
            IPeriodRepository periodsRepository,
            IHotelImageRepository hotelImageRepository,
            IOccupiedDateRepository occupateDateRepository)
        {
            _context = context;
            Hotels = hotelsRepository;
            Periods = periodsRepository;
            HotelImages = hotelImageRepository;
            HotelOccupiedDates = occupateDateRepository;
        }

        public IHotelRepository Hotels { get; private set; }
        public IPeriodRepository Periods { get; private set; }
        public IHotelImageRepository HotelImages { get; private set; }
        public IOccupiedDateRepository HotelOccupiedDates { get; private set; }

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
