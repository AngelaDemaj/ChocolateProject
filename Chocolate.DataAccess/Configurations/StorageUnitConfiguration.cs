using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class StorageUnitConfiguration : IEntityTypeConfiguration<StorageUnit>
    {
        public void Configure(EntityTypeBuilder<StorageUnit> builder)
        {
            builder.HasKey(su => su.Id);

            builder.Property(su => su.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(su => su.Warehouse)
                .WithMany(w => w.StorageUnits)
                .HasForeignKey(su => su.WarehouseId)
                .IsRequired();

            builder.HasMany(su => su.Sectors)
                .WithOne(s => s.StorageUnit);
        }
    }
}
