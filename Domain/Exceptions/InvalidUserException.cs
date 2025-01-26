namespace Domain.Exceptions
{
    internal class InvalidUserException : DomainException
    {
        public InvalidUserException(string message, string errorCode) : base(message, errorCode) { }
        public InvalidUserException(string message, string errorCode,Exception innerException) : base(message, errorCode,innerException) { }

        public static InvalidUserException InvalidRolePermition()
            =>new InvalidUserException("Role is Invalid",
                                        "USER_INVALID_ROLE_PERMITION");



    }
}
