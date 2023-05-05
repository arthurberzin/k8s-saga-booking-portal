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
    public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
            builder.HasOne(it => it.Employee).WithOne(it => it.Position).HasForeignKey<Employee>(it => it.PositionId);
        }
    }
}
