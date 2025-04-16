using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InazumaAPI.Domain.Events
{
    public interface IEventHandler<in TDomainEvent> where TDomainEvent : class, IEvent
    {
        Task HandleAsync(TDomainEvent @event);

        bool CanHandle(TDomainEvent @event);
    }
}
