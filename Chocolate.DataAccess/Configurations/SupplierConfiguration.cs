using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Ignore(s => s.FullName);

            builder.Property(s => s.Name)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(s => s.Type)
                .HasMaxLength(50)
                .IsRequired(); ;
        }
    }
}
