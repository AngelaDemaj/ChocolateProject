using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.HireDate)
                .IsRequired();

            builder.Property(e => e.WorkExperience)
                .HasMaxLength(1000);

            builder.HasMany(e => e.Leaves)
                .WithOne(l => l.Employee)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
