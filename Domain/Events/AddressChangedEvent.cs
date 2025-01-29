

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




        /// <summary>
        /// Returns a string representation of the event
        /// </summary>
        public override string ToString()
        {
            return $"Address Changed [Old: {OldAddress}, New: {NewAddress}]";
        }
    }
}
