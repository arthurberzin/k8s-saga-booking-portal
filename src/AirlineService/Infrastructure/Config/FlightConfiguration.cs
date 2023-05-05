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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();

            builder.HasMany(it => it.AircraftAssignments).WithOne(it => it.Flight).HasForeignKey(it=>it.FlightId);

            builder.HasMany(it => it.FlightBookings).WithOne(it => it.Flight).HasForeignKey(it => it.FlightId);

            builder.HasMany(it => it.Crews).WithOne(it => it.Flight).HasForeignKey(it => it.FlightId);

            builder.HasOne(it => it.ArrivalAirport).WithMany(it=>it.ArrivalFlights).HasForeignKey(it => it.ArrivalAirportId);
            builder.HasOne(it => it.DepartureAirport).WithMany(it=>it.DepartureFlights).HasForeignKey(it => it.DepartureAirportId);
        }
    }
}
