using HireMe.Core.Models;
using MediatR;

namespace HireMe.Core.DomainEvents
{
    public class EmployeerCreatedEvent : INotification
    {
        public Employeer Employeer { get; }
        public EmployeerCreatedEvent(Employeer employeer)
        {
            Employeer = employeer;
        }
    }
}
