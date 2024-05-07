﻿using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configrations
{
    public class ServiceConfigurations : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500;
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.).IsRequired();

            builder.HasIndex(x => new { x.Id, x.Delete }).IsUnique();
        }
    }
}
