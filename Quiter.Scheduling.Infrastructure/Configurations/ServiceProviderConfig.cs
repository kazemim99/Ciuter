using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiter.Scheduling.Infrastructure.DataModel;

namespace Quiter.Scheduling.Infrastructure.Configurations
{
    internal class ServiceProviderConfig : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("varchar(255)").IsUnicode();
        }
    }
}
