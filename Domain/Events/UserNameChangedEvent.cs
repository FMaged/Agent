
using Domain.ValueObjects;

namespace Domain.Events
{
    public class UserNameChangedEvent:DomainEvent
    {
        public UserName OldUserName { get;}
        public UserName NewUserName { get;}


        public UserNameChangedEvent() { }

        public UserNameChangedEvent(UserName oldUserName, UserName newUserName)
        {
            OldUserName = oldUserName;  
            NewUserName = newUserName;
        }





    }
}
