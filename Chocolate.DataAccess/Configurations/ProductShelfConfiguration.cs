using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    class ProductShelfConfiguration : IEntityTypeConfiguration<ProductShelf>
    {
        public void Configure(EntityTypeBuilder<ProductShelf> builder)
        {
            builder.HasKey(ps => new { ps.ProductId, ps.ShelfId });

            builder.HasIndex(ps => new
            {
                ps.ProductId,
                ps.ShelfId,
            })
                .IsUnique();

            builder.HasOne(ps => ps.Product)
                .WithMany(p => p.Shelves)
                .HasForeignKey(ps => ps.ProductId)
                .IsRequired();

            builder.HasOne(ps => ps.Shelf)
                .WithMany(s => s.Products)
                .HasForeignKey(ps => ps.ShelfId);

            builder.Property(ps => ps.Quantity);
        }
    }
}