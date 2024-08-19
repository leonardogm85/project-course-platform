using CoursePlatform.Core.Messages;

using FluentValidation;
using FluentValidation.Results;

namespace CoursePlatform.Identity.Application.Commands.Roles;

public class RemoveRoleCommand(Guid id) : Command(id)
{
    public Guid Id { get; } = id;

    public override ValidationResult GetValidationResult()
    {
        return new RemoveRoleValidation().Validate(this);
    }

    private class RemoveRoleValidation : AbstractValidator<RemoveRoleCommand>
    {
        public RemoveRoleValidation()
        {
            RuleFor(role => role.Id)
                .NotEmpty()
                .WithMessage("The id must be provided.");
        }
    }
}
