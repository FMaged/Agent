
using Domain.Enums;

namespace Domain.Events
{
    public class EmployeeStatusUpdatedEvent:DomainEvent
    {
        public eEmployeesStatus OldStatus { get; }
        public eEmployeesStatus NewStatus { get; }

        public EmployeeStatusUpdatedEvent() { }

        public EmployeeStatusUpdatedEvent(eEmployeesStatus oldStatus, eEmployeesStatus newStatus)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }






        /// <summary>
        /// Returns a string representation of the event
        /// </summary>
        public override string ToString()
        {
            return $"Status changed [Old: {OldStatus}, New: {NewStatus}]";
        }
    }
}
