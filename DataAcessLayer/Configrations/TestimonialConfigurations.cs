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
    public class TestimonialConfigurations : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Message)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Suranme)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
