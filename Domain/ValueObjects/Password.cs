﻿    using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Password:BaseObject
    {
        public string Value { get; }
        public Password(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw InvalidUserException.MissingPassword();
            if (plainPassword.Length < 8 || plainPassword.Length > 20)


                throw InvalidUserException.InvalidPassword(this);///??? this ????
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$";
            if (!Regex.IsMatch(plainPassword, pattern))
                throw InvalidUserException.InvalidPassword(this);

            Value = HashPassword(plainPassword);
        }
        private string HashPassword(string plainPassword)
        {
            // Implementation using proper password hashing (e.g., BCrypt)
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
