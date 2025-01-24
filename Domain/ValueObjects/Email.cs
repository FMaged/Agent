using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    internal class Email
    {
        public string Value {  get;}
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidEmailException("Email cannot be empty");
        var Trimmed=value.Trim();
        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(Trimmed, pattern))
                throw new InvalidEmailException("Invalid email format");
        Value = Trimmed;


        }



    }
}
