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
    public class CrewConfiguration : IEntityTypeConfiguration<CrewAssignment>
    {
        public void Configure(EntityTypeBuilder<CrewAssignment> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasOne(it=>it.Flight).WithMany(it=>it.Crew).HasForeignKey(it => it.FlightId);
            builder.HasOne(it => it.Employee).WithOne(it => it.Crew).HasForeignKey<Employee>(it => it.CrewId);
        }
    }
}
