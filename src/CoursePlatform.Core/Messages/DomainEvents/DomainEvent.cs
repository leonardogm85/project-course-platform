using MediatR;

namespace CoursePlatform.Core.Messages.DomainEvents;

public abstract class DomainEvent : Message, INotification
{
    public DateTimeOffset Timestamp { get; }

    protected DomainEvent(Guid aggregateId) : base(aggregateId)
    {
        Timestamp = DateTimeOffset.UtcNow;
    }
}
