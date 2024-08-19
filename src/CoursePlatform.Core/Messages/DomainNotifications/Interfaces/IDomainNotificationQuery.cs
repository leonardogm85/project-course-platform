namespace CoursePlatform.Core.Messages.DomainNotifications.Interfaces;

public interface IDomainNotificationQuery : IDisposable
{
    IReadOnlyCollection<DomainNotification> GetNotifications();
    bool HasNotification();
}
