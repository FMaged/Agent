namespace Domain.Exceptions
{
    internal class InvalidEmployeeException : DomainException
    {
        

        public InvalidEmployeeException(string message,string errorCode) : base(message,errorCode) 
        { 

        }
        public InvalidEmployeeException(string message, string errorCode, Exception innerException) : base(message, errorCode ,innerException)
        {

        }
        public static InvalidEmployeeException MissingStatus()
            => new InvalidEmployeeException("Status is required",
                                            "EMPLOYEE_MISSING_STATUS");
        


        public static InvalidEmployeeException InvalidStatus()
            =>  new InvalidEmployeeException("Invalid Status",
                                             "EMPLOYEE_INVALID_STATUS");








    }
}
