using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Location)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Country)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.PostCode)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.AddressNumber)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Comments)
                .HasMaxLength(1000);

            builder.HasOne(a => a.Supplier)
                .WithMany(s => s.Addresses);

        }
    }
}
