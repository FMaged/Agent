namespace Domain.Exceptions
{
    internal class InvalidPhoneNumberException : DomainException
    {
        public InvalidPhoneNumberException(string message) : base(message) { }
    }
}
