
using Domain.Enums;

namespace Domain.Events
{
    public class JobApplicationStatusUpdatedEvent:DomainEvent
    {
        public eApplicationsStatus OldStatus { get;}
        public eApplicationsStatus NewStatus { get;}

        public JobApplicationStatusUpdatedEvent() { }

        public JobApplicationStatusUpdatedEvent(eApplicationsStatus oldStatus, eApplicationsStatus newStatus)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }






    }
}
