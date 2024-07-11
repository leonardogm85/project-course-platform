using CoursePlatform.Core.Mediator;
using CoursePlatform.Core.Mediator.Interfaces;
using CoursePlatform.Core.Messages.DomainNotifications;
using CoursePlatform.Core.Messages.DomainNotifications.Handlers;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace CoursePlatform.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
    }
}
