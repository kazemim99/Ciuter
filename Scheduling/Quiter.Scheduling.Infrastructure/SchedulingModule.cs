using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiter.Scheduling.Infrastructure.Seed;
using Shared.Data;
using Shared.Data.Seed;

namespace Quiter.Scheduling.Infrastructure
{
    public static class SchedulingModule
    {
        public static IServiceCollection AddSchedulingModule(this IServiceCollection services,
        IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");


            services.AddDbContext<SchedulingDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IDataSeeder, SeedSchedule>();

            return services;
        }

        public static IApplicationBuilder UseSchedulingModule(this IApplicationBuilder app)
        {

            app.UseMigration<SchedulingDbContext>();

            return app;
        }
    }
}
