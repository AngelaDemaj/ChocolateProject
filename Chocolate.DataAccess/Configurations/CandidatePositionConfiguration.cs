using Chocolate.DataAccess.Configurations.Extensions;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chocolate.DataAccess.Configurations
{
    public class CandidatePositionConfiguration : IEntityTypeConfiguration<CandidatePosition>
    {
        public void Configure(EntityTypeBuilder<CandidatePosition> builder)
        {
            builder.HasKey(cp => new { cp.CandidateId, cp.PositionId });

            builder.HasIndex(cp => new
            {
                cp.CandidateId,
                cp.PositionId,
                cp.RecruitStatus
            })
                .IsUnique();

            builder.HasOne(cp => cp.Candidate)
                .WithMany(p => p.CandidatePositions)
                .HasForeignKey(cp => cp.CandidateId)
                .IsRequired();

            builder.HasOne(cp => cp.Position)
                .WithMany(c => c.CandidatePositions)
                .HasForeignKey(cp => cp.PositionId)
                .IsRequired();

            builder.Property(cp => cp.RecruitStatus)
                .HasDefaultValue(RecruitStatus.Unopened);

            builder.HasEnumCheckConstraint(cp => cp.RecruitStatus);
        }
    }
}
