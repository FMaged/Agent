

namespace Domain.Exceptions
{
    internal class InvalidAddressException: DomainException
    {
        public InvalidAddressException(string message) : base(message) { }

    }
}
