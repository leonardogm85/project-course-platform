using CoursePlatform.Core.Mediator.Interfaces;
using CoursePlatform.Core.Messages;
using CoursePlatform.Core.Messages.DomainEvents;
using CoursePlatform.Core.Messages.DomainNotifications;
using CoursePlatform.Core.Messages.IntegrationEvents;

using MediatR;

namespace CoursePlatform.Core.Mediator;

public sealed class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task PublishEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : Event
    {
        await _mediator.Publish(@event, cancellationToken);
    }

    public async Task<bool> SendCommandAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : Command
    {
        return await _mediator.Send(command, cancellationToken);
    }

    public async Task PublishDomainEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : DomainEvent
    {
        await _mediator.Publish(@event, cancellationToken);
    }

    public async Task PublishIntegrationEventAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IntegrationEvent
    {
        await _mediator.Publish(@event, cancellationToken);
    }

    public async Task PublishDomainNotificationAsync(DomainNotification notification, CancellationToken cancellationToken)
    {
        await _mediator.Publish(notification, cancellationToken);
    }
}
