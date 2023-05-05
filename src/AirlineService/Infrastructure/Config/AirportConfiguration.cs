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
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasMany(it => it.ArrivalFlights).WithOne(it => it.ArrivalAirport).HasForeignKey(it=>it.ArrivalAirportId);
            builder.HasMany(it => it.DepartureFlights).WithOne(it => it.DepartureAirport).HasForeignKey(it=>it.DepartureAirportId);

        }
    }
}
