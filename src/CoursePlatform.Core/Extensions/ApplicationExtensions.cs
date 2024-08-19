using CoursePlatform.Core.Mediator;
using CoursePlatform.Core.Mediator.Interfaces;
using CoursePlatform.Core.Messages.DomainNotifications;
using CoursePlatform.Core.Messages.DomainNotifications.Handlers;
using CoursePlatform.Core.Messages.DomainNotifications.Interfaces;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace CoursePlatform.Core.Extensions;

public static class ApplicationExtensions
{
    public static void AddCoreContext(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        services.AddScoped<IDomainNotificationQuery, DomainNotificationHandler>();
    }
}
