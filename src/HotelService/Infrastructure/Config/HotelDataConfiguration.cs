using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Config
{
    internal class HotelDataConfiguration : IEntityTypeConfiguration<HotelData>
    {
        public void Configure(EntityTypeBuilder<HotelData> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id).IsRequired();  
        }
    }
}
