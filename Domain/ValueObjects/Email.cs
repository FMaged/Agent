using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Email:BaseObject
    {
        public string Value { get; }
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw InvalidEmailException.MissingEmail();
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            var Trimmed = value.Trim();
            if (!Regex.IsMatch(Trimmed, pattern))
                throw InvalidEmailException.InvalidEmail(this);
            Value = Trimmed;


        }

        // Define equality components (only the email value)
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
