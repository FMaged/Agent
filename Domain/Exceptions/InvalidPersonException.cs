namespace Domain.Exceptions
{
    internal class InvalidPersonException : DomainException
    {
        public InvalidPersonException(string message, string errorCode) : base(message, errorCode) { }
        public InvalidPersonException(string message, string errorCode,Exception innerException) : base(message, errorCode,innerException) { }

        public static InvalidPersonException MissingName()
            => new InvalidPersonException("Name is required",
                                          "PERSON_MISSING_NAME");
        public static InvalidPersonException MissingDate()
            => new InvalidPersonException("Date is required",
                                          "PERSON_MISSING_DATE");
        public static InvalidPersonException MissingEnum()
    => new InvalidPersonException("Gender is required",
                                  "PERSON_MISSING_GENDER");







        public static InvalidPersonException InvalidName(string name)
            => new InvalidPersonException($"Name '{name}' is invalid",
                                           "PERSON_INVALID_NAME");

        public static InvalidPersonException InvalidDate(DateTime date)
            => new InvalidPersonException($"Date '{date}' is invalid",
                                           "PERSON_INVALID_DATE");
        public static InvalidPersonException InvalidGender()
            => new InvalidPersonException($"Gender is invalid",
                                           "PERSON_INVALID_GENDER");


    }
}
