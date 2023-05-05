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
    public class AircraftAssignmentConfiguration : IEntityTypeConfiguration<AircraftAssignment>
    {
        public void Configure(EntityTypeBuilder<AircraftAssignment> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasOne(it => it.Aircraft).WithMany(it => it.Assignments).HasForeignKey(it => it.AircraftId);
            builder.HasOne(it => it.Flight).WithMany(it => it.AircraftAssignments).HasForeignKey(it => it.FlightId);
        }
    }
}
