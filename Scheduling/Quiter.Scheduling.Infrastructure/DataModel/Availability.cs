using Shared.DDD;

namespace Quiter.Scheduling.Infrastructure.DataModel
{
    public class Availability : Entity<Guid>
    {
        public Guid Id { get; private set; }
        public TimeSlot TimeSlot { get; private set; }
        public bool IsAvailable { get; private set; }

        private Availability()
        {
                
        }
        public Availability(TimeSlot timeSlot)
        {
            Id = Guid.NewGuid();
            TimeSlot = timeSlot;
            IsAvailable = true;
        }

        public void MarkAsUnavailable()
        {
            IsAvailable = false;
        }
        public void SetAvailabelity(bool available)
        {
            IsAvailable = available;
        }

    }
}
