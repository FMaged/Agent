
using Domain.ValueObjects;

namespace Domain.Events
{
    public class PasswordChangedEvent:DomainEvent
    {
        public Password OldPassword { get; }
        public Password NewPassword { get; }

        public PasswordChangedEvent() { }
        public PasswordChangedEvent(Password oldPassword, Password newPassword)
        {
            OldPassword = oldPassword;
            NewPassword = newPassword;


        }




    }
}
