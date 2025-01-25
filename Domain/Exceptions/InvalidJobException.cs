namespace Domain.Exceptions
{
    internal class InvalidJobException : DomainException
    {
        public InvalidJobException(string message) : base(message) { }

    }
}
