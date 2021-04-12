using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    class RawMaterialShelfConfiguration : IEntityTypeConfiguration<RawMaterialShelf>
    {
        public void Configure(EntityTypeBuilder<RawMaterialShelf> builder)
        {
            builder.HasKey(ps => new { ps.RawMaterialId, ps.ShelfId });

            builder.HasOne(ps => ps.RawMaterial)
                .WithMany(p => p.Shelves)
                .HasForeignKey(ps => ps.RawMaterialId);

            builder.HasOne(ps => ps.Shelf)
                .WithMany(s => s.RawMaterials)
                .HasForeignKey(ps => ps.ShelfId);
        }
    }
}
