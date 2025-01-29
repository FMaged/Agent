
using Domain.Entities;

namespace Domain.Events
{
    public class JobApplicationCreatedEvent:DomainEvent
    {
        public JobApplications jobApplication {  get;}


        public JobApplicationCreatedEvent() { }

        public  JobApplicationCreatedEvent(JobApplications jobApplication)
        {
            this.jobApplication = jobApplication;
        }







    }
}
