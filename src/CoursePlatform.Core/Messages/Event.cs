using MediatR;

namespace CoursePlatform.Core.Messages;

public abstract class Event : Message, INotification
{
    public DateTimeOffset Timestamp { get; }

    protected Event(Guid aggregateId) : base(aggregateId)
    {
        Timestamp = DateTimeOffset.UtcNow;
    }
}
