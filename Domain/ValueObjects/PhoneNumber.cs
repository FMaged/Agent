using Domain.Exceptions;

namespace Domain.ValueObjects
{
    internal class PhoneNumber
    {
        public string Value { get;}
        public PhoneNumber (string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidPhoneNumberException("Phone number cannot be empty");
            if (value.Length != 10)
                throw new InvalidPhoneNumberException("Phone number must be 10 digits");
            //Validate the New Value 






            this.Value = value;
        }


    }
}
