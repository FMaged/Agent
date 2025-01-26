namespace Domain.Exceptions
{
    internal class InvalidJobApplicationException : DomainException
    {
        public InvalidJobApplicationException(string message,string errorCode) : base(message,errorCode) { }
        public InvalidJobApplicationException(string message, string errorCode,Exception InnerException):base(message,errorCode,InnerException) { }






        public static InvalidJobApplicationException InvalidDate(DateTime Date)
            => new InvalidJobApplicationException($"Date '{Date}' is invalid",
                                                   "APPLICATION_INVALID_DATE");

        public static InvalidJobApplicationException InvalidStatus()
            => new InvalidJobApplicationException($"Status is invalid",
                                                   "APPLICATIOn_INVALID_STATUS");





    }
}
