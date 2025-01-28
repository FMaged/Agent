using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class UserName:BaseObject
    {
        public string Value { get; }

        public UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw InvalidUserException.MissingUserName();

            var trimmed = value.Trim();

            if (trimmed.Length < 5 || trimmed.Length > 20)
                throw InvalidUserException.InvalidUserName(this);

            var pattern = @"^[A-Za-z][A-Za-z0-9._-]{4,19}$";
            if (!Regex.IsMatch(trimmed, pattern))
                throw InvalidUserException.InvalidUserName(this);

            Value = trimmed;

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;   
         }
    }
}
