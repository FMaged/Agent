using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class Employees:BaseEntity<int>
    {
        public override int Id => Employees_ID;
        public int Employees_ID { get;private set; }
        public string? Position { get;private set; }
        public eEmployeesStatus? Status { get;private set; }
        public int Employees_Person_ID { get;private set; }

        private Employees()
        {
            Employees_ID = default!;
            Position = default!;
            Status = default!;
            Employees_Person_ID = default!;
        }
        private Employees(int employees_ID, string position, eEmployeesStatus status, int employees_person_ID)
        {
            ValidateStatus(status);
            ValidateID(employees_person_ID);
            ValidateID(employees_ID);
            Employees_ID = employees_ID;
            Position = position;
            Status = status;
            Employees_Person_ID = employees_person_ID;
        }
        private Employees(string position, eEmployeesStatus status, int employees_person_ID)
        {
            ValidateStatus(status);
            ValidateID(employees_person_ID);
            
            Position = position;
            Status = status;
            Employees_Person_ID = employees_person_ID;
        }

        public static Employees FromDatabase(int employees_ID, string position, eEmployeesStatus status, int employees_person_ID)
        {
            return new Employees(employees_ID,position, status, employees_person_ID);
        }
        public static Employees CreateEmployee(string position, eEmployeesStatus status, int employees_person_ID)
        {
            return new Employees(position, status, employees_person_ID);
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
                throw new InvalidEmployeeException("Invalid Id");
        }
        private void ValidateStatus(eEmployeesStatus status)
        {
            if (!Enum.IsDefined(typeof(eEmployeesStatus), status))
                throw new InvalidEmployeeException("Invalid EmployeesStatus");
        }

    }
}
