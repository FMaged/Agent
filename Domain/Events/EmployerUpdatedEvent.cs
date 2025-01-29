
using Domain.Entities;

namespace Domain.Events
{
    public class EmployerUpdatedEvent:DomainEvent
    {
        public Employer OldEmployer {  get;}
        public Employer NewEmployer { get;}

        public EmployerUpdatedEvent() { }


        public EmployerUpdatedEvent(Employer oldEmployer, Employer newEmployer)
        {
            OldEmployer = oldEmployer;
            NewEmployer = newEmployer;

        }








    }
}
