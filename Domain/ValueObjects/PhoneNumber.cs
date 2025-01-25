using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class PhoneNumber:BaseObject
    {
        public string CountryCode { get; }
        public string Number { get; }
        public PhoneNumber(string number , string countryCode)
        {

            if (string.IsNullOrWhiteSpace(number))
                throw new InvalidPhoneNumberException("Phone number cannot be empty");
            if (number.Length != 10)
                throw new InvalidPhoneNumberException("Phone number must be 10 digits");
            //Validate the New Value 





            CountryCode = countryCode;
            Number = number;
        }

        // Compare both CountryCode and Number
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CountryCode;
            yield return Number;
        }
    }
}
