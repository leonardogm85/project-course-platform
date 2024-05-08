using MediatR;

namespace CoursePlatform.Core.Messages;

public abstract class Event : Message, INotification
{
    public DateTime Timestamp { get; }

    protected Event(Guid aggregateId) : base(aggregateId)
    {
        Timestamp = DateTime.UtcNow;
    }
}
