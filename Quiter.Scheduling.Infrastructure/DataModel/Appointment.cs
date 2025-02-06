using Quiter.Scheduling.Models.Enums;
using Shared.DDD;

namespace Quiter.Scheduling.Infrastructure.DataModel
{
    public class Appointment : Aggregate<Guid>
    {
        public Customer Customer { get; private set; }
        public ServiceProvider ServiceProvider { get; private set; }
        public TimeSlot TimeSlot { get; private set; }
        
        public AppointmentStatus Status { get; private set; }

        private Appointment()
        {

        }
        public Appointment(Customer customer, ServiceProvider serviceProvider, TimeSlot timeSlot, AppointmentStatus status)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            ServiceProvider = serviceProvider;
            TimeSlot = timeSlot;
            Status = status;
        }
        public void Create(Customer customer, ServiceProvider serviceProvider, TimeSlot timeSlot, AppointmentStatus status)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            ServiceProvider = serviceProvider;
            TimeSlot = timeSlot;
            Status = status;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
