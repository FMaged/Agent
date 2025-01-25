namespace Domain.Exceptions
{
    internal class InvalidEmployeeException : DomainException
    {
        public InvalidEmployeeException(string message) : base(message) { }

    }
}
