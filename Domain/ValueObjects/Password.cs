using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Password
    {
        public string Value { get;}
        public Password(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new InvalidUserException("Password cannot be empty");
            if (plainPassword.Length < 8 || plainPassword.Length > 20)
                throw new InvalidUserException("Password must be 8-20 characters");
            var pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$";
            if(!Regex.IsMatch(plainPassword, pattern))
                throw new InvalidUserException("Password must contain uppercase, lowercase, number, and special character");
            
            Value = HashPassword(plainPassword);
        }
        private string HashPassword(string plainPassword)
        {
            // Implementation using proper password hashing (e.g., BCrypt)
            throw new NotImplementedException();
        }






    }
}
