using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(w => w.StorageUnits)
                .WithOne(s => s.Warehouse)
                .HasForeignKey(s => s.WarehouseId)
                .IsRequired();

            builder.HasMany(w => w.StorageUnits)
                .WithOne(s => s.Warehouse)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
