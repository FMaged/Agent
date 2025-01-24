using Domain.Enums;

namespace Domain.Entities
{
    public class Employees
    {
        public int Employees_ID { get; set; }
        public string? Position { get; set; }
        public eEmployeesStatus? Status { get; set; }
        public int Employees_Person_ID { get; set; }

        public Employees(int employees_ID,string position, eEmployeesStatus status,int employees_person_ID)
        {
            Employees_ID = employees_ID;
            Position = position;
            Status = status;
            Employees_Person_ID = employees_person_ID;
        }
        public Employees(string position, eEmployeesStatus status, int employees_person_ID)
        {
            Position = position;
            Status = status;
            Employees_Person_ID = employees_person_ID;
        }


    }
}
