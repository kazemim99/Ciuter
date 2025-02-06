using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Quiter.Scheduling.Infrastructure.DataModel;

namespace Quiter.Scheduling.Infrastructure
{
    public class SchedulingDbContext : DbContext
    {
        public SchedulingDbContext(DbContextOptions<SchedulingDbContext> options)
        : base(options) { }

        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Availability> Availabilities => Set<Availability>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<ServiceProvider> ServiceProviders => Set<ServiceProvider>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("scheduling");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
