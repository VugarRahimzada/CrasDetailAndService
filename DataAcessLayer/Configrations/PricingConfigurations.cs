using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configrations
{
    public class PricingConfigurations : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Price).HasPrecision(7, 2);
            builder.HasMany(x=>x.PriceDescription).WithOne(x=>x.Pricing).HasForeignKey(x=>x.Id);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
