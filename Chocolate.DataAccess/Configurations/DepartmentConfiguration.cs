using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name)
                .HasMaxLength(60);

            builder.HasIndex(d => d.Name)
                .IsUnique();

            builder.HasMany(d => d.Employees)
                   .WithOne(e => e.Department)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
