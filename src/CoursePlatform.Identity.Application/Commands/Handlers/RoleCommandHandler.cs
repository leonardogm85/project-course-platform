using CoursePlatform.Core.Mediator.Interfaces;
using CoursePlatform.Core.Messages;
using CoursePlatform.Core.Messages.DomainNotifications;
using CoursePlatform.Identity.Application.Commands.Roles;
using CoursePlatform.Identity.Domain.Constants;
using CoursePlatform.Identity.Domain.Entities;
using CoursePlatform.Identity.Domain.Interfaces.Repositories;

using MediatR;

namespace CoursePlatform.Identity.Application.Commands.Handlers;

public class RoleCommandHandler :
    IRequestHandler<AddRoleCommand, bool>,
    IRequestHandler<UpdateRoleCommand, bool>,
    IRequestHandler<RemoveRoleCommand, bool>
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IRoleRepository _roleRepository;

    public RoleCommandHandler(IMediatorHandler mediatorHandler, IRoleRepository roleRepository)
    {
        _mediatorHandler = mediatorHandler;
        _roleRepository = roleRepository;
    }

    public async Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (!await IsValidAsync(request, cancellationToken))
        {
            return false;
        }

        var createdBy = Guid.NewGuid();

        var role = new Role(
            request.Name,
            createdBy);

        _roleRepository.AddRole(role);

        return await _roleRepository.UnitOfWork.CommitAsync(cancellationToken);
    }

    public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (!await IsValidAsync(request, cancellationToken))
        {
            return false;
        }

        var role = await _roleRepository.GetRoleByIdAsync(request.Id, cancellationToken);

        if (role is null)
        {
            var notification = new DomainNotification(
                nameof(Role),
                Messages.RecordNotFound);

            await _mediatorHandler.PublishDomainNotificationAsync(
                notification,
                cancellationToken);

            return false;
        }

        if (role.ConcurrencyStamp != request.ConcurrencyStamp)
        {
            var notification = new DomainNotification(
                nameof(Role),
                Messages.DatabaseConcurrencyError);

            await _mediatorHandler.PublishDomainNotificationAsync(
                notification,
                cancellationToken);

            return false;
        }

        if (!role.Active)
        {
            var notification = new DomainNotification(
                nameof(Role),
                Messages.InactiveRecordCannotBeUpdated);

            await _mediatorHandler.PublishDomainNotificationAsync(
                notification,
                cancellationToken);

            return false;
        }

        var updatedBy = Guid.NewGuid();

        role.SetName(request.Name);

        role.EntityUpdatedBy(updatedBy);

        _roleRepository.UpdateRole(role);

        return await _roleRepository.UnitOfWork.CommitAsync(cancellationToken);
    }

    public async Task<bool> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (!await IsValidAsync(request, cancellationToken))
        {
            return false;
        }

        var role = await _roleRepository.GetRoleByIdAsync(request.Id, cancellationToken);

        if (role is null)
        {
            var notification = new DomainNotification(
                nameof(Role),
                Messages.RecordNotFound);

            await _mediatorHandler.PublishDomainNotificationAsync(
                notification,
                cancellationToken);

            return false;
        }

        _roleRepository.RemoveRole(role);

        return await _roleRepository.UnitOfWork.CommitAsync(cancellationToken);
    }

    private async Task<bool> IsValidAsync(Command request, CancellationToken cancellationToken)
    {
        var validationResult = request.GetValidationResult();

        if (validationResult.IsValid)
        {
            return true;
        }

        foreach (var error in validationResult.Errors)
        {
            var notification = new DomainNotification(
                request.MessageType,
                error.ErrorMessage);

            await _mediatorHandler.PublishDomainNotificationAsync(
                notification,
                cancellationToken);
        }

        return false;
    }
}
