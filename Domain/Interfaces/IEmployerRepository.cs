using Domain.ValueObjects;


using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployerRepository
    {
        // Basic CRUD operations
        Employer GetById(int employerId);
        Employer GetByName(string employerName);
        Employer GetByRegistration_Number(RegistrationNumber registrationNumber);
        void Add(Employer employer);
        void Update(Employer employer);
        void Delete(int employerId);



    }
}
