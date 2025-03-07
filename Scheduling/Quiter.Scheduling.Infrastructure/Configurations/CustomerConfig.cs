using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiter.Scheduling.Infrastructure.DataModel;

namespace Quiter.Scheduling.Infrastructure.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.Name).HasColumnType("varchar(255)").IsUnicode();

        }
    } 
}
