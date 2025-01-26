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
                throw InvalidPhoneNumberException.MissingNumber();
            if (number.Length != 10)
                throw InvalidPhoneNumberException.InvalidNumber(number);
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
