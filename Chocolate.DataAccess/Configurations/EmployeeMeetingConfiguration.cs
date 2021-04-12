using Chocolate.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.DataAccess.Configurations
{
    public class EmployeeMeetingConfiguration : IEntityTypeConfiguration<EmployeeMeeting>
    {
        public void Configure(EntityTypeBuilder<EmployeeMeeting> builder)
        {
            builder.HasKey(em => new { em.EmployeeId, em.MeetingId });

            builder.HasOne(em => em.Employee)
                .WithMany(e => e.EmployeeMeetings)
                .HasForeignKey(em => em.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(em => em.Meeting)
                .WithMany(m => m.EmployeeMeetings)
                .HasForeignKey(em => em.MeetingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
