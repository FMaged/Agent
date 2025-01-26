
namespace Domain.Exceptions
{
    internal class DomainException : Exception
    {
        private string ErrorCode { get; }
        public DomainException(string message,string errorCode) : base(message) 
        {
            ErrorCode = errorCode;
        }
        public DomainException(string message, string errorCode, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        
        public static DomainException Missing_ID()
            =>  new DomainException("ID is required",
                                    "DOMAIN_MISSING_ID");
        public static DomainException Invalid_ID(int Id)
            =>  new DomainException($"{Id} is Invalid",
                                    "DOMAIN_INVALID_ID");
    
    
    
    }
}
