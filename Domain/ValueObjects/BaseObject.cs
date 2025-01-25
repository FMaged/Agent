

namespace Domain.ValueObjects
{
    public abstract class BaseObject
    {
        // Override this method to return all properties relevant for equality checks
        protected abstract IEnumerable<object> GetEqualityComponents();

        // Compare all components for equality
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (BaseObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
        // Generate a hash code from all components
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }

        // Override equality operators
        public static bool operator ==(BaseObject left, BaseObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
                return false;

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool operator !=(BaseObject left, BaseObject right)
        {
            return !(left == right);
        }



    }
}
