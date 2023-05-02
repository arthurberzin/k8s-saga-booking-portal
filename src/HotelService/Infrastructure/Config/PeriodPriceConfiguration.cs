using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Infrastructure.Config
{
    internal class PeriodPriceConfiguration : IEntityTypeConfiguration<PeriodPrice>
    {
        public void Configure(EntityTypeBuilder<PeriodPrice> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();
        }
    }
}
