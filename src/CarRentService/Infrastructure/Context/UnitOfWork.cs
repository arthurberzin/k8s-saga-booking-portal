using CarRent.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context,
            ICarRepository carRepository )
        {
            _context = context;
            Cars = carRepository;
        }

        public ICarRepository Cars { get; private set; }
        public ICarOccupiedDateRepository OccupiedDates { get; private set; }
        public ILocationRepository Locations { get; private set; }
        
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
