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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasOne(it=>it.Crew).WithOne(it=>it.Employee).HasForeignKey<Crew>(it => it.EmployeeId);
            builder.HasOne(it=>it.Position).WithOne(it=>it.Employee).HasForeignKey<EmployeePosition>(it => it.EmployeeId);
        }
    }
}
