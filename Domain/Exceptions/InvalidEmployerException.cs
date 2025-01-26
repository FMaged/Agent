namespace Domain.Exceptions
{
    internal class InvalidEmployerException : DomainException
    {
        public InvalidEmployerException(string message, string errorCode) : base(message,errorCode) { }
        public InvalidEmployerException(string message,string errorCode,Exception InnerException):base(message,errorCode,InnerException) { }


        public static InvalidEmployerException MissingCompanyName()
            => new InvalidEmployerException("Company name is required",
                                            "EMPLOYER_MISSING_COMPANYNAME");
        public static InvalidEmployerException MissingIndustry()
    => new InvalidEmployerException("Industry is required",
                                    "EMPLOYER_MISSING_INDUSTRY");






        public static InvalidEmployerException InvalidCompanySize(int? companySize)
            =>new InvalidEmployerException($"Company Size '{companySize}' is invalid",
                                            "EMPLOYER_INVALID_SIZE");

        public static InvalidEmployerException InvalidCompanyName(string companyName)
            => new InvalidEmployerException($"Company Name '{companyName}' is invalid",
                                            "EMPLOYER_INVALID_NAME");
        public static InvalidEmployerException InvalidIndustry()
            => new InvalidEmployerException("Industry is Invalid",
                                            "EMPLOYER_INVALID_NDUSTRY");

    }
}
