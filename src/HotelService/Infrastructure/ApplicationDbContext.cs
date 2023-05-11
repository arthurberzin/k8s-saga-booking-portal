using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Hotel.Models;

namespace Hotel.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<PeriodPrice> Periods => Set<PeriodPrice>();

        public DbSet<HotelData> Hotels => Set<HotelData>();
        public DbSet<HotelImage> HotelImages => Set<HotelImage>();
        public DbSet<HotelOccupiedDate> HotelOccupateDates => Set<HotelOccupiedDate>();


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<HotelData>().Navigation(e => e.Prices).AutoInclude();
            modelBuilder.Entity<HotelData>().Navigation(e => e.OccupiedDates).AutoInclude();
            modelBuilder.Entity<HotelData>().Navigation(e => e.Images).AutoInclude();
        }
    }
}