using MediatR;
using Quiter.Scheduling.Event;
using Quiter.Scheduling.Repository;

namespace Quiter.Scheduling.EventHandler
{
    public class AppointmentCancelledHandler : INotificationHandler<AppointmentCancelled>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAvailabilityRepository _availabilityRepository;

        public AppointmentCancelledHandler(IAppointmentRepository appointmentRepository, IAvailabilityRepository availabilityRepository)
        {
            _appointmentRepository = appointmentRepository;
            _availabilityRepository = availabilityRepository;
        }

        public async Task Handle(AppointmentCancelled @event, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAsync(@event.AppointmentId);
            var availability = await _availabilityRepository.GetAvailability(appointment.ServiceProvider.Id, appointment.TimeSlot);

            // Mark the time slot as available again after cancellation
            availability.MarkAsUnavailable();

            // Cancel the appointment
            appointment.Cancel();
            await _appointmentRepository.SaveChangesAsync(cancellationToken);
        }
    }

}
