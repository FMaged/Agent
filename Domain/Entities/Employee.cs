using Domain.Enums;
using Domain.Exceptions;
using Domain.Events;

namespace Domain.Entities
{
    public class Employee:BaseEntity<int>
    {
        public override int Id => Employees_ID;
        public int Employees_ID { get;private set; }
        public string? Position { get;private set; }
        public eEmployeesStatus Status { get; private set; } = eEmployeesStatus.Active;
        public Person Employees_Person { get;private set; }

        private Employee()
        {
            Employees_ID = default!;
            Position = default!;
            Status = default!;
            Employees_Person = default!;
        }
        private Employee(int employees_ID, string position, eEmployeesStatus status, Person employees_person)
        {
            ValidateStatus(status);
            ValidateID(employees_ID);
            Employees_ID = employees_ID;
            Position = position;
            Status = status;
            Employees_Person = employees_person;
        }
        private Employee(string position, eEmployeesStatus status, Person employees_person)
        {
            ValidateStatus(status);            
            Position = position;
            Status = status;
            Employees_Person = employees_person;


            //will it Work giving (this) inside of the Constructer ?????
            AddDomainEvent(new EmployeeCreatedEvent(this));

        }

        public static Employee FromDatabase(int employees_ID, string position, eEmployeesStatus status, Person employees_person)
        {
            return new Employee(employees_ID,position, status, employees_person);
        }
        public static Employee CreateEmployee(string position, eEmployeesStatus status, Person employees_person)
        {
            Employee CreatedEmployee = new Employee(position, status, employees_person);
            return CreatedEmployee;


        }




        public void Update(string position)
        {
            Position = position;
        
        
        
        }
        public void Update(eEmployeesStatus status)
        {
            ValidateStatus(status);
            eEmployeesStatus OldStatus = this.Status;
            Status= status;

            AddDomainEvent(new EmployeeStatusUpdatedEvent(OldStatus,this.Status));
        }



        public void UpdateEmployee(string position, eEmployeesStatus status)
        {
            ValidateStatus(status);
            this.Position = position;
            this.Status = status;
        }




        private void ValidateID(int ID)
        {
            if (ID > 1)
                throw DomainException.Missing_ID();
        }
        private void ValidateStatus(eEmployeesStatus status)
        {
            if (!Enum.IsDefined(typeof(eEmployeesStatus), status))
                throw InvalidEmployeeException.InvalidStatus();


        }

    }
}
