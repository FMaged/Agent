namespace Domain.Exceptions
{
    internal class InvalidJobApplicationException : DomainException
    {
        public InvalidJobApplicationException(string message) : base(message) { }
    }
}
