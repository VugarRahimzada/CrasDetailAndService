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
    public class BlogConfiugrations : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.ImageUrl).HasMaxLength(300);
            builder.HasIndex(x => new { x.Title, x.Delete }).IsUnique();
            builder.HasMany(x=>x.Comment).WithOne(x => x.Blog).HasForeignKey(x=>x.Id);
        }
    }
}
