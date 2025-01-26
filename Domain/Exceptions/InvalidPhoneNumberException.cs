namespace Domain.Exceptions
{
    internal class InvalidPhoneNumberException : DomainException
    {
        public InvalidPhoneNumberException(string message, string errorCode) : base(message, errorCode) { }
        public InvalidPhoneNumberException(string message, string errorCode,Exception innerException) : base(message, errorCode,innerException) { }


        public static InvalidPhoneNumberException MissingNumber()
            => new InvalidPhoneNumberException("Phone Number is required",
                                                "PHONE_NUMBER_MISSING");





        public static InvalidPhoneNumberException InvalidNumber(string number)
            => new InvalidPhoneNumberException($"the Number '{number}' is invalid",
                                                "PHONE_NUMBER_INVALID");            


    }
}
