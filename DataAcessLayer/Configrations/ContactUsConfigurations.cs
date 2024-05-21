using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configrations
{
    public class ContactUsConfigurations : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Subject)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(x => x.Message)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Surname)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.HasIndex(x => new { x.Email, x.Delete }).IsUnique();
        }
    }
}
