
namespace Domain.Exceptions
{
    internal class InvalidPersonException:DomainException
    {
        public InvalidPersonException(string message) : base(message) { }
    }
}
