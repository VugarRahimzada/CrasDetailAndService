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
    public class TeamConfigurations : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(300);
            builder.Property(x => x.LinkedInUrl).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Position).IsRequired().HasMaxLength(300);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
