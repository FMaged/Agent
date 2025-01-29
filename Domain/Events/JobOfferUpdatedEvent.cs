
using Domain.Entities;

namespace Domain.Events
{
    public class JobOfferUpdatedEvent:DomainEvent
    {
        public Job_Offer OldJob { get;}
        public Job_Offer NewJob { get;}


        public JobOfferUpdatedEvent() { }


        public JobOfferUpdatedEvent(Job_Offer oldJob, Job_Offer newJob)
        {
            OldJob = oldJob;
            NewJob = newJob;

        }







    }
}
