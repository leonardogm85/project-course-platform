using MediatR;

namespace CoursePlatform.Core.Messages.DomainNotifications;

public sealed class DomainNotification : Message, INotification
{
    public Guid DomainNotificationId { get; }
    public string Key { get; }
    public string Value { get; }
    public int Version { get; }
    public DateTimeOffset Timestamp { get; }

    public DomainNotification(string key, string value) : base(Guid.NewGuid())
    {
        DomainNotificationId = AggregateId;

        Key = key;
        Value = value;

        Version = 1;
        Timestamp = DateTimeOffset.UtcNow;
    }
}
