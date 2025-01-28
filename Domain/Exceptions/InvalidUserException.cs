using Domain.ValueObjects;

namespace Domain.Exceptions
{
    internal class InvalidUserException : DomainException
    {
        public InvalidUserException(string message, string errorCode) : base(message, errorCode) { }
        public InvalidUserException(string message, string errorCode,Exception innerException) : base(message, errorCode,innerException) { }

        public static InvalidUserException MissingUserName()
        => new InvalidUserException("UserName is required",
                                      "USER_MISSING_USERNAME");
        public static InvalidUserException MissingPassword()
        => new InvalidUserException("Password is required",
                                      "USER_MISSING_PASSWORD");







        public static InvalidUserException InvalidUserName(UserName userName)
           => new InvalidUserException($"UserName {userName} is Invalid",
                                       "USER_INVALID_USERNAME");

        public static InvalidUserException InvalidPassword(Password password)
           => new InvalidUserException($"Password {password} is Invalid",
                                       "USER_INVALID_PASSWORD");


        public static InvalidUserException InvalidRolePermeation()
            =>new InvalidUserException("Role is Invalid",
                                        "USER_INVALID_ROLE_PERMITION");









    }
}
