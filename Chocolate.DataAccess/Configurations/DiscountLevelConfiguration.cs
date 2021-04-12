using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class DiscountLevelConfiguration : IEntityTypeConfiguration<DiscountLevel>
    {
        public void Configure(EntityTypeBuilder<DiscountLevel> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Amount)
                .IsRequired();

            builder.Property(d => d.DiscountPercentage)
                .IsRequired();

            builder.HasOne(d => d.Discount)
                .WithMany(e => e.Levels)
                .HasForeignKey(d => d.DiscountId);
        }
    }
}
