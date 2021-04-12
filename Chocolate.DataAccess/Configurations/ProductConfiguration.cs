using Chocolate.DataAccess.Configurations.Extensions;
using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.HasIndex(p => p.Barcode)
                .IsUnique();

            builder.Property(p => p.Barcode)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.Weight)
                .IsRequired();

            builder.Property(p => p.IsDeleted)
                .IsRequired();

            builder.HasEnumCheckConstraint(p => p.Category);

            builder.Property(p => p.Category)
                .IsRequired();
        }
    }
}
