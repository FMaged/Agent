
using Domain.Entities;

namespace Domain.Events
{
    public class EmployeeCreatedEvent:DomainEvent
    {
        public Employee CreatedEmployee { get;}


        public EmployeeCreatedEvent(Employee employee)
        {
            CreatedEmployee = employee;
        }



    }
}
