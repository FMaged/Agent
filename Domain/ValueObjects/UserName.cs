

using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class UserName
    {
        public string Value { get;}

        public UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidUserException("Username cannot be empty");

            var trimmed = value.Trim();

            if (trimmed.Length < 5 || trimmed.Length > 20)
                throw new InvalidUserException("Username must be 5-20 characters");

            var pattern = @"^[A-Za-z][A-Za-z0-9._-]{4,19}$";
            if (!Regex.IsMatch(trimmed, pattern))
                throw new InvalidUserException("Invalid username format");

            Value = trimmed;

        }


    }
}
