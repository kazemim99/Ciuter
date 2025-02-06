using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiter.Scheduling.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiter.Scheduling.Infrastructure.Configurations
{
    internal class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {

            builder.HasKey(c => c.Id);

            builder.OwnsOne(a => a.TimeSlot, ts =>
            {
                ts.Property(t => t.StartTime)
                  .IsRequired()
                  .HasColumnName("StartTime");

                ts.Property(t => t.EndTime)
                  .IsRequired()
                  .HasColumnName("EndTime");
            });
        }
    }
}
