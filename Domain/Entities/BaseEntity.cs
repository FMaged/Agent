
namespace Domain.Entities
{
    public abstract class BaseEntity<TId> where TId : notnull
    {
        public abstract TId Id { get; }

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity<TId> other) return false;
            if(ReferenceEquals(this, other)) return true;
            if(GetType()!=other.GetType()) return false;  
            return Id.Equals(other.Id);
        }

        public override int GetHashCode() =>Id.GetHashCode();

        public static bool operator ==(BaseEntity<TId>left, BaseEntity<TId> right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }
        public static bool operator !=(BaseEntity<TId> left, BaseEntity<TId> right) => !(left == right);

    }
}
