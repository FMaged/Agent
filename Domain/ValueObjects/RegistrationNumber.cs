
namespace Domain.ValueObjects
{
    public class RegistrationNumber:BaseObject
    {
        public string Value { get; }

        public RegistrationNumber(string value)
        {
            //Validate the Number here 





            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
