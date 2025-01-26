using Domain.ValueObjects;

namespace Domain.Exceptions
{
    internal class InvalidEmailException : DomainException
    {
        public InvalidEmailException(string message,string errorCode) : base(message,errorCode) { }
    
        public InvalidEmailException(string message,string errorCode,Exception InnerException):base(message,errorCode,InnerException) { }
    
        public static InvalidEmailException MissingEmail()
            => new InvalidEmailException("Email is required",
                                         "EMAIL_MISSING_EMAIL");




        public static InvalidEmailException InvalidEmail(Email  email)
            => new InvalidEmailException($"Postal code '{email.Value}' is invalid",
                                          "ADDRESS_INVALID_POSTAL_CODE");

    }
}
