using MediatR;
using Quiter.Scheduling.Infrastructure.DataModel;
using Shared.DDD;

namespace Quiter.Scheduling.Event
{
    public class AvailabilityUpdated : INotification
    {
        public Guid ServiceProviderId { get; private set; }
        public TimeSlot TimeSlot { get; private set; }
        public bool IsAvailable { get; private set; }

        public AvailabilityUpdated(Guid serviceProviderId, TimeSlot timeSlot, bool isAvailable)
        {
            ServiceProviderId = serviceProviderId;
            TimeSlot = timeSlot;
            IsAvailable = isAvailable;
        }
    }

}
