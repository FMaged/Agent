using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Email
    {
        public string Value {  get;}
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidEmailException("Email cannot be empty");
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var Trimmed=value.Trim();
            if (!Regex.IsMatch(Trimmed, pattern))
                throw new InvalidEmailException("Invalid email format");
            Value = Trimmed;


        }



    }
}
