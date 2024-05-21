using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configrations
{
    public class AboutConfiugrations : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Vision)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(x => x.History)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(x => x.Misson)
                   .IsRequired()
                   .HasMaxLength(2000);
        }
    }
}
