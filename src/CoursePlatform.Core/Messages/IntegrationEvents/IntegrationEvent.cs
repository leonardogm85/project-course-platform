using MediatR;

namespace CoursePlatform.Core.Messages.IntegrationEvents;

public abstract class IntegrationEvent : Message, INotification
{
    public DateTimeOffset Timestamp { get; }

    protected IntegrationEvent(Guid aggregateId) : base(aggregateId)
    {
        Timestamp = DateTimeOffset.UtcNow;
    }
}
