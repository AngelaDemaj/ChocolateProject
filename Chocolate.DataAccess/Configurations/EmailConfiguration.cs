using Chocolate.DataAccess.Configurations.Extensions;
using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.Property(e => e.Mail)
                .HasMaxLength(50);

            builder.HasIndex(e => e.Mail)
                .IsUnique();

            builder.HasEnumCheckConstraint(e => e.MailType);
        }
    }
}
