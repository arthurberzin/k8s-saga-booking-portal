using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Config
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.Navigation(it => it.CurrentLocation).AutoInclude();
            builder.Navigation(it => it.OccupiedDates).AutoInclude();
            builder.HasOne(it => it.CurrentLocation).WithOne().HasForeignKey<Location>(it=> it.CarId);
            builder.HasMany(it=>it.OccupiedDates).WithOne().HasForeignKey(it => it.CarId);
        }
    }
}
