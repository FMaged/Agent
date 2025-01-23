

namespace Domain.Exceptions
{
    internal class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message) { }

    }
}
