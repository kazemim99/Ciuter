using MediatR;
using Quiter.Scheduling.Event;
using Quiter.Scheduling.Infrastructure.DataModel;
using Quiter.Scheduling.Models;
using Quiter.Scheduling.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiter.Scheduling.EventHandler
{
    public class AppointmentScheduledHandler : INotificationHandler<AppointmentScheduled>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAvailabilityRepository _availabilityRepository;

        public AppointmentScheduledHandler(IAppointmentRepository appointmentRepository, IAvailabilityRepository availabilityRepository)
        {
            _appointmentRepository = appointmentRepository;
            _availabilityRepository = availabilityRepository;
        }

        public async Task Handle(AppointmentScheduled @event, CancellationToken cancellationToken)
        {
            // Mark the time slot as unavailable after an appointment is scheduled
            var availability = await _availabilityRepository.GetAvailability(@event.ServiceProviderId, @event.TimeSlot);
            availability.MarkAsUnavailable();


            // You might want to save the appointment in the repository here
            var appointment = new Appointment(
                new Customer(@event.CustomerId.ToString()),
                new ServiceProvider(@event.ServiceProviderId.ToString()),
                @event.TimeSlot,Models.Enums.AppointmentStatus.Created
            );

            await _appointmentRepository.SaveChangesAsync(cancellationToken);
        }
    }

}
