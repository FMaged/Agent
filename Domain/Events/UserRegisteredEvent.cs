using Domain.Entities;
using Domain.user.Aggregate;


namespace Domain.Events
{
    public class UserRegisteredEvent:DomainEvent
    {
        public User RegisteredUser {  get;}

        public UserRegisteredEvent() { }

        public UserRegisteredEvent(User registeredUser)
        {
            this.RegisteredUser = registeredUser;
        }







    }
}
