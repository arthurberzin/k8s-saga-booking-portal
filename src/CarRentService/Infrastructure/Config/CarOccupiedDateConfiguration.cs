using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Config
{
    internal class CarOccupiedDateConfiguration : IEntityTypeConfiguration<CarOccupiedDate>
    {
        public void Configure(EntityTypeBuilder<CarOccupiedDate> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasOne<Car>().WithMany(it=>it.OccupiedDates).HasForeignKey(it=> it.CarId);
        }
    }
}
