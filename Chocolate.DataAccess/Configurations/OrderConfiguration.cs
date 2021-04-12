using Chocolate.DataAccess.Configurations.Extensions;
using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasEnumCheckConstraint(o => o.PaymentType);

            builder.Property(o => o.PaymentType)
                .IsRequired();

            builder.Property(o => o.OrderPlaced)
                .IsRequired();
        }
    }
}
