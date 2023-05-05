using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.Models;

namespace Airline.Infrastructure
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasOne(it=>it.Flight).WithMany(it=>it.FlightBookings).HasForeignKey(it => it.FlightId);
        }
    }
}
