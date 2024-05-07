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
    public class FAQConfigurations : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Question).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Answer).IsRequired().HasMaxLength(2000);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
