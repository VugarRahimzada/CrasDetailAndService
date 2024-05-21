using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configrations
{
    public class BlogConfiugrations : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Text)
                   .IsRequired();

            builder.Property(x => x.ImageUrl)
                   .HasMaxLength(300);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
