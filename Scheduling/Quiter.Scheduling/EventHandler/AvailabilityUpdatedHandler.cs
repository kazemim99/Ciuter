using MediatR;
using Quiter.Scheduling.Event;
using Quiter.Scheduling.Repository;

namespace Quiter.Scheduling.EventHandler
{
    public class AvailabilityUpdatedHandler : INotificationHandler<AvailabilityUpdated>
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public AvailabilityUpdatedHandler(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task Handle(AvailabilityUpdated @event, CancellationToken cancellationToken)
        {
            var availability = await _availabilityRepository.
                GetAvailability(@event.ServiceProviderId, @event.TimeSlot);

            if (availability != null)
            {
                availability.SetAvailabelity(@event.IsAvailable);
                await _availabilityRepository.SaveChanged();
            }
        }
    }

}
