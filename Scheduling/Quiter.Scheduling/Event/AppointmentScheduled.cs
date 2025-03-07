using MediatR;
using Quiter.Scheduling.Infrastructure.DataModel;
using Shared.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiter.Scheduling.Event
{
    public class AppointmentScheduled : INotification
    {
        public Guid AppointmentId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ServiceProviderId { get; private set; }
        public TimeSlot TimeSlot { get; private set; }

        public AppointmentScheduled(Guid appointmentId, Guid customerId, Guid serviceProviderId, TimeSlot timeSlot)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            ServiceProviderId = serviceProviderId;
            TimeSlot = timeSlot;
        }
    }

}
