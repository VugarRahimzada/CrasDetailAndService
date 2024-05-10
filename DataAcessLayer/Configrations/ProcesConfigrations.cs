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
    public class ProcesConfigrations : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x=> x.Description).IsRequired().HasMaxLength(300);
            builder.Property(x=> x.Icon).IsRequired().HasMaxLength(300);

            builder.HasIndex(x => new { x.Title, x.Delete }).IsUnique();
        }
    }
}
