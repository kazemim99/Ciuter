using Shared.DDD;

namespace Quiter.Scheduling.Infrastructure.DataModel
{
    public class Customer : Entity<Guid>
    {
        public string Name { get; private set; }


        private Customer()
        {

        }
        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
