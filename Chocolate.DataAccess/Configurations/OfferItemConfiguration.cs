using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class OfferItemConfiguration : IEntityTypeConfiguration<OfferItem>
    {
        public void Configure(EntityTypeBuilder<OfferItem> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Quantity)
                .IsRequired();

            //builder.Ignore(o => o.OfferItemCost);

            builder.HasOne(o => o.RawMaterial)
                .WithMany(r => r.OfferItems)
                .IsRequired();

            builder.HasOne(o => o.Offer)
                .WithMany(o => o.OfferItems)
                .IsRequired();
        }
    }
}
