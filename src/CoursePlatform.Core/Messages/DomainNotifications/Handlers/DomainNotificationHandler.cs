using MediatR;

namespace CoursePlatform.Core.Messages.DomainNotifications.Handlers;

public sealed class DomainNotificationHandler : INotificationHandler<DomainNotification>, IDisposable
{
    private readonly List<DomainNotification> _notifications = [];

    public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _notifications.Add(notification);

        return Task.CompletedTask;
    }

    public IReadOnlyCollection<DomainNotification> GetNotifications() => _notifications.AsReadOnly();

    public bool HasNotification() => _notifications.Count > 0;

    public void Dispose() => _notifications.Clear();
}
