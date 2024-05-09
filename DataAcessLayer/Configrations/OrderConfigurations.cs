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
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(300);
            builder.Property(x => x.LicensePlate).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.LicensePlate).IsUnique();
            builder.HasOne(x => x.Pricing).WithMany(x => x.Order).HasForeignKey(x => x.PricingId);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
