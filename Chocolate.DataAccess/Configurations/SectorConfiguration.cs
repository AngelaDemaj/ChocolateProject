using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(s => s.StorageUnit)
                .WithMany(su => su.Sectors)
                .IsRequired();

            builder.HasMany(s => s.Shelves)
                .WithOne(sh => sh.Sector)
                .HasForeignKey(s => s.SectorId);
        }
    }
}
