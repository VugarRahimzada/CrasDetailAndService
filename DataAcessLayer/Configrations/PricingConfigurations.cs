using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configrations
{
    public class PricingConfigurations : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(x => x.Price)
                   .HasPrecision(7, 2);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
