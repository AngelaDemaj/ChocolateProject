using Chocolate.DataAccess.Configurations.Extensions;
using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(p => p.Number)
                    .IsRequired();

            builder.HasIndex(p => p.Number)
                    .IsUnique();

            builder.HasEnumCheckConstraint(p => p.PhoneType);
        }
    }
}
