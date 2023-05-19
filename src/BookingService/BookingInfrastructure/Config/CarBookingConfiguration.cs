using Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Config
{
    internal class CarBookingConfiguration : IEntityTypeConfiguration<CarBooking>
    {
        public void Configure(EntityTypeBuilder<CarBooking> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            
        }
    }
}
