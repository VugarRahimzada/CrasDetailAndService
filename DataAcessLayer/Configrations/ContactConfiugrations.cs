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
    public class ContactConfiugrations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
