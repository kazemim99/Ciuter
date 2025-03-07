using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiter.Scheduling.Infrastructure.DataModel;

namespace Quiter.Scheduling.Infrastructure.Configurations
{
    internal class AvailabilityConfig : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IsAvailable).HasColumnType("BOOLEAN");


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
