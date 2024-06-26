﻿using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configrations
{
    public class PricingDescriptionConfigurations : IEntityTypeConfiguration<PriceDescription>
    {
        public void Configure(EntityTypeBuilder<PriceDescription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(500);
            builder.HasOne(x => x.Pricing)
                   .WithMany(x => x.PriceDescription)
                   .HasForeignKey(x => x.PricingId);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
