using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class LeaveHistoryConfiguration : IEntityTypeConfiguration<LeaveHistory>
    {
        public void Configure(EntityTypeBuilder<LeaveHistory> builder)
        {
            builder.Property(lh => lh.Comments)
                   .HasMaxLength(1000);

            builder.HasOne(lh => lh.Leave)
                .WithMany(l => l.LeaveHistories)
                .HasForeignKey(lh => lh.LeaveId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
