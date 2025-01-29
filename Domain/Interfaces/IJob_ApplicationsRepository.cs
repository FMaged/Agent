
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IJob_ApplicationsRepository
    {
        JobApplications GetById(int jobApplicationId);
        void Add(JobApplications jobApplication);
        void Update(JobApplications jobApplication);
        void Delete(int jobApplicationId);






    }
}
