
using Domain.ValueObjects;

namespace Domain.Events
{
    public class EmailUpdatedEvent:DomainEvent
    {
        public Email OldEmail { get;}
        public Email NewEmail { get;}

        public EmailUpdatedEvent(Email oldEmail, Email newEmail)
        {
            OldEmail = oldEmail;
            NewEmail = newEmail;
        }

    }
}
