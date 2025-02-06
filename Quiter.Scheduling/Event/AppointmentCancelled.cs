using MediatR;
using Shared.DDD;

namespace Quiter.Scheduling.Event
{
    public class AppointmentCancelled : INotification
    {
        public Guid AppointmentId { get; private set; }

        public AppointmentCancelled(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }

}
