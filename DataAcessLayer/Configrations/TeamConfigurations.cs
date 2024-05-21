using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configrations
{
    public class TeamConfigurations : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Surname)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(x => x.LinkedInUrl)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Position)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(x => x.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.HasIndex(x => new { x.Name, x.Delete })
                   .IsUnique();
        }
    }
}
