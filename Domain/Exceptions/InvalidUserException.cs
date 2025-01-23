
namespace Domain.Exceptions
{
    internal class InvalidUserException:DomainException
    {
        public InvalidUserException(string message) : base(message) { }
    }
}
