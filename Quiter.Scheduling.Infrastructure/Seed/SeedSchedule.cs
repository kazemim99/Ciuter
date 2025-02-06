using Microsoft.EntityFrameworkCore;
using Quiter.Scheduling.Infrastructure;
using Quiter.Scheduling.Infrastructure.DataModel;
using Shared.Data.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiter.Scheduling.Infrastructure.Seed
{
    internal class SeedSchedule(SchedulingDbContext dbContext) : IDataSeeder
    {
        public async Task SeedAllAsync()
        {
            if (!await dbContext.Appointments.AnyAsync())
            {
                await dbContext.Appointments.AddRangeAsync(InitialData.Appointments);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    internal class InitialData
    {

        public static IEnumerable<Appointment> Appointments =>
  [
      new Appointment(new Customer("Name-1"),new ServiceProvider("Service-1"),new TimeSlot(),Models.Enums.AppointmentStatus.Avalable),
      new Appointment(new Customer("Name-2"),new ServiceProvider("Service-2"),new TimeSlot(),Models.Enums.AppointmentStatus.Canceled),
      new Appointment(new Customer("Name-3"),new ServiceProvider("Service-3"),new TimeSlot(),Models.Enums.AppointmentStatus.Done),
      new Appointment(new Customer("Name-4"),new ServiceProvider("Service-4"),new TimeSlot(),Models.Enums.AppointmentStatus.Avalable),
   ];
    }


}
