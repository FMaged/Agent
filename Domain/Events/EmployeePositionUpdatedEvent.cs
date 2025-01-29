

namespace Domain.Events
{
    public class EmployeePositionUpdatedEvent:DomainEvent
    {
        public string OldPosition { get;}
        public string NewPosition { get;}

        public EmployeePositionUpdatedEvent() { }

        public EmployeePositionUpdatedEvent(string oldPosition, string newPosition)
        {
            OldPosition = oldPosition;
            NewPosition = newPosition;
        }




    }
}
