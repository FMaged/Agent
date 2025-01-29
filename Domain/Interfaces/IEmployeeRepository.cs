
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        // Basic CRUD operations
        Employee GetById(int employeeId);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int employeeId);



        // Domain-specific queries
        Employee FindByEmail(string email);



    }
}
