using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id);

            //builder.Ignore(d => d.IsActive);

            builder.Property(d => d.EndDate)
                .IsRequired();

            builder.HasOne(d => d.Supplier)
                .WithMany(s => s.Discounts)
                .HasForeignKey(d => d.SupplierId)
                .IsRequired();
        }
    }
}
