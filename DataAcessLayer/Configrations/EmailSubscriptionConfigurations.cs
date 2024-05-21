using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configrations
{
    public class EmailSubscriptionConfigurations : IEntityTypeConfiguration<EmailSubscription>
    {
        public void Configure(EntityTypeBuilder<EmailSubscription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(300);

        }
    }
}
