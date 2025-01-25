


namespace Domain.ValueObjects
{
    public class WebSite:BaseObject
    {
        public string Value { get; }
        public WebSite(string value) 
        {
            //Validate the URL
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
