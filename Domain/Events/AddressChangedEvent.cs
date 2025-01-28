

using Domain.Entities;

namespace Domain.Events
{
    public class AddressChangedEvent:DomainEvent
    {
        public Address OldAddress {  get; }
        public Address NewAddress { get; }


        public AddressChangedEvent(Address oldAddress, Address newAddress) 
        {
            OldAddress = oldAddress;
            NewAddress = newAddress;
        }




    }
}
