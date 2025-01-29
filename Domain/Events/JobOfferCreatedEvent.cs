
using Domain.Entities;

namespace Domain.Events
{
    public class JobOfferCreatedEvent:DomainEvent
    {
        public Job_Offer CreatedJob { get;}

        public JobOfferCreatedEvent() { }
        public JobOfferCreatedEvent(Job_Offer CreatedJob)
        {
            this.CreatedJob = CreatedJob;
        }









    }
}
