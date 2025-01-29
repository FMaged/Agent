
using Domain.Entities;

namespace Domain.Events
{
    public sealed class EmployeeCreatedEvent:DomainEvent
    {
        public Employee CreatedEmployee { get;}

        // Required for serialization
        protected EmployeeCreatedEvent() { }
        public EmployeeCreatedEvent(Employee employee)
        {
            CreatedEmployee = employee;
        }



        /// <summary>
        /// Returns a string representation of the event
        /// </summary>
        public override string ToString()
        {
            return $"Employee Created [ID: {CreatedEmployee.Id}, Name: {CreatedEmployee.Employees_Person.Last_Name}]";
        }
    }
}
