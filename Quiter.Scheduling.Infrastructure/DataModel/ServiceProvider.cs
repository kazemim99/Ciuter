using Shared.DDD;

namespace Quiter.Scheduling.Infrastructure.DataModel
{
    public class ServiceProvider : Entity<Guid>
    {
        public string Name { get; private set; }
        public List<Availability> Availabilities { get; private set; }


        private ServiceProvider() { }
        public ServiceProvider(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Availabilities = new List<Availability>();
        }

        public void AddAvailability(TimeSlot timeSlot)
        {
            Availabilities.Add(new Availability(timeSlot));
        }

        public bool IsAvailable(TimeSlot timeSlot)
        {
            return Availabilities.Any(a => a.TimeSlot.Equals(timeSlot) && a.IsAvailable);
        }
    }
}
