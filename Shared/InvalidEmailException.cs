

namespace Domain.Exceptions
{
    internal class InvalidEmailException:DomainException
    {
        public InvalidEmailException(string message) : base(message) { }
    }
}
