using Domain.ValueObjects;

namespace Domain.Exceptions
{
    internal class InvalidJobException : DomainException
    {
        public InvalidJobException(string message,string errorCode) : base(message,errorCode) { }
        public InvalidJobException(string message, string errorCode,Exception innerException) : base(message, errorCode,innerException) { }

        public static InvalidJobException MissingName()
            => new InvalidJobException("ID is required",
                                        "JOBOFFER_MISSING_ID");

        public static InvalidJobException MissingEnum()
            => new InvalidJobException("Enum is required",
                                        "JOBOFFER_MISSING_ENUM");



        public static InvalidJobException InvalidName(string name)
            =>new InvalidJobException($"Job Name '{name}' is invalid",
                                       "JOBOFFER_INVALID_JOBNAME");
        public static InvalidJobException InvalidEnum(Enum eEnum)
            => new InvalidJobException($"Enum '{eEnum}' is invalid",
                                        "JOBOFFER_INVALID_ENUM");

        public static InvalidJobException InvalidDate(DateTime date)
             => new InvalidJobException($"Date '{date}' is invalid",
                                         "JOBOFFER_INVALID_DATE");
        public static InvalidJobException InvalidSalary(SalaryRange range)
            => new InvalidJobException($"Salary '{range.Maximum} - {range.Minimum}' is invalid",
                                        "JOBOFFER_INVALID_SALARYRANGE");
        public static InvalidJobException InvalidDescription(string description)
            => new InvalidJobException($"Description'{description}' is invalid",
                                        "JOBOFFER_INVALID_DESCRIPTION");
    }
}
