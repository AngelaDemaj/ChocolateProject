using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.DepartmentId)
                .IsRequired();

            builder.HasIndex(p => p.Name)
                .IsUnique();

            builder.Property(p => p.Description)
                .HasMaxLength(2000);

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(p => p.Degree)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.WorkExperience)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Languages)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Qualifications)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
