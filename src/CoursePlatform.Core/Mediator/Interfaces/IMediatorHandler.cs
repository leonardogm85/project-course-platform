using CoursePlatform.Core.Messages;
using CoursePlatform.Core.Messages.DomainEvents;
using CoursePlatform.Core.Messages.DomainNotifications;
using CoursePlatform.Core.Messages.IntegrationEvents;

namespace CoursePlatform.Core.Mediator.Interfaces;

public interface IMediatorHandler
{
    Task PublishEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : Event;
    Task<bool> SendCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : Command;
    Task PublishDomainEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : DomainEvent;
    Task PublishIntegrationEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IntegrationEvent;
    Task PublishDomainNotificationAsync(DomainNotification notification, CancellationToken cancellationToken);
}
