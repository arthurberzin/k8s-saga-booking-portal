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
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasOne(it => it.Booking).WithOne(it => it.Seat).HasForeignKey<Booking>(it => it.SeatId);
            builder.HasOne(it => it.Flight).WithMany(it => it.SeatsBookings).HasForeignKey(it => it.FlightId);
        }
    }
}
