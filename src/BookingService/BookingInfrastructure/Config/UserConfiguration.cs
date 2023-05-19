using Booking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Config
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasMany(it=>it.CarBookings).WithOne().HasForeignKey(it=>it.UserId);
            builder.HasMany(it=>it.HotelBookings).WithOne().HasForeignKey(it=>it.UserId);
            builder.HasMany(it=>it.FlightBookings).WithOne().HasForeignKey(it=>it.UserId);
        }
    }
}
