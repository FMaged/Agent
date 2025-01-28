
using Domain.Events;
using Domain.Exceptions;
using System.Collections.Immutable;

namespace Domain.Entities
{
    public abstract class BaseEntity<TId> where TId : notnull
    {
        // Track all domain events for this entity
        private readonly List<DomainEvent> _domainEvents = new();

        // Expose events as read-only
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.ToImmutableList();

        // Add an event to the collection
        public void AddDomainEvent(DomainEvent domainEvent)
        {
            if (domainEvent is null)
                throw new DomainException("Event cant be Null","DOMAIN_MISSING_EVENT");
            _domainEvents.Add(domainEvent);
        }


        // Clear events after they’re dispatched
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

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
