using Chocolate.DataAccess.Configurations.Extensions;
using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.Property(l => l.Status)
                   .IsRequired();

            builder.HasEnumCheckConstraint(l => l.Status);

            builder.HasEnumCheckConstraint(l => l.LeaveType);

            builder.HasMany(l => l.LeaveHistories)
                .WithOne(lh => lh.Leave)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Employee)
                   .WithMany(e => e.Leaves)
                   .HasForeignKey(l => l.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
