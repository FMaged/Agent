using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class SalaryRange:BaseObject
    {
        public decimal Minimum { get; }
        public decimal Maximum { get; }

        public SalaryRange(decimal minimum, decimal maximum)
        {
            if (Minimum > Maximum)
                throw new InvalidJobException("Minimum salary cannot be greater than maximum salary");
            if (Minimum < 0 || Maximum < 0)
                throw new InvalidJobException("Salary values must be non-negative");

            Minimum = minimum;
            Maximum = maximum;

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Minimum;
            yield return Maximum;
            
        }
    }
}
