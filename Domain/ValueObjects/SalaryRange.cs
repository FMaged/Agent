
namespace Domain.ValueObjects
{
    public class SalaryRange
    {
        public decimal Minimum { get;}
        public decimal Maximum { get;}

        public SalaryRange(decimal minimum, decimal maximum)
        {
            Minimum = minimum;
            Maximum = maximum;

        }

    }
}
