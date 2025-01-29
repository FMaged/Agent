
using Domain.ValueObjects;

namespace Domain.Events
{
    public class PhoneNumberUpdatedEvent:DomainEvent
    {
        public PhoneNumber OldNumber { get;}
        public PhoneNumber NewNumber { get;}

        public PhoneNumberUpdatedEvent() { }


        public PhoneNumberUpdatedEvent(PhoneNumber oldNumber,PhoneNumber newNumber) 
        {
            OldNumber = oldNumber;
            NewNumber = newNumber;
        }










    }
}
