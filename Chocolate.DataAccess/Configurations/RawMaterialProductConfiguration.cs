using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    class RawMaterialProductConfiguration : IEntityTypeConfiguration<RawMaterialProduct>
    {
        public void Configure(EntityTypeBuilder<RawMaterialProduct> builder)
        {
            builder.HasKey(rmp => new { rmp.RawMaterialId, rmp.ProductId });

            builder.HasIndex(rmp => new
            {
                rmp.RawMaterialId,
                rmp.ProductId
            })
                .IsUnique();

            builder.HasOne(rmp => rmp.RawMaterial)
                .WithMany(r => r.Products)
                .HasForeignKey(rmp => rmp.RawMaterialId)
                .IsRequired();

            builder.HasOne(rmp => rmp.Product)
                .WithMany(p => p.RawMaterialProducts)
                .HasForeignKey(rmp => rmp.ProductId)
                .IsRequired();
        }
    }
}