using InazumaAPI.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Domain.Aggregates
{
    public abstract class Aggregate
    {
        protected Aggregate()
        {
            DomainEvents = new List<IEvent>();
        }

        public ICollection<IEvent> DomainEvents { get; private set; }

        public void AddDomainEvent(IEvent @event)
        {
            DomainEvents.Add(@event);
        }
    }
}
