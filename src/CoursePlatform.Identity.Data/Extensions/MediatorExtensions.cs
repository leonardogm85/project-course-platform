using CoursePlatform.Core.Domain;
using CoursePlatform.Core.Mediator.Interfaces;
using CoursePlatform.Identity.Data.Context;

namespace CoursePlatform.Identity.Data.Extensions;

public static class MediatorExtensions
{
    public static async Task PublishEventsAsync(this IMediatorHandler mediator, IdentityContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var domainEntities = context
            .ChangeTracker
            .Entries<Entity>()
            .Where(entry => entry.Entity.HasEvents())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(entry => entry.Entity.GetEvents())
            .ToList();

        domainEntities
            .ForEach(entry => entry.Entity.ClearEvents());

        context
            .ChangeTracker
            .Clear();

        var taskEvents = domainEvents
            .Select(async @event => await mediator.PublishEventAsync(@event, cancellationToken));

        await Task.WhenAll(taskEvents);
    }
}
