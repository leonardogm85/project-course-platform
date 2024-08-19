using CoursePlatform.Core.Mediator.Interfaces;
using CoursePlatform.Core.Messages.DomainNotifications;
using CoursePlatform.Core.Messages.DomainNotifications.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CoursePlatform.Api.Controllers.Base;

public abstract class BaseController : Controller
{
    protected readonly IMediatorHandler _mediatorHandler;
    protected readonly IDomainNotificationQuery _domainNotificationQuery;

    protected BaseController(IMediatorHandler mediatorHandler, IDomainNotificationQuery domainNotificationQuery)
    {
        _mediatorHandler = mediatorHandler;
        _domainNotificationQuery = domainNotificationQuery;
    }

    protected bool HasNotification()
    {
        return _domainNotificationQuery.HasNotification();
    }

    protected IEnumerable<string> GetNotifications()
    {
        return _domainNotificationQuery.GetNotifications()
            .Select(n => n.Value)
            .ToList();
    }

    protected async Task PublishNotificationAsync(DomainNotification domainNotification, CancellationToken cancellationToken)
    {
        await _mediatorHandler.PublishDomainNotificationAsync(domainNotification, cancellationToken);
    }
}
