using CoursePlatform.Core.Messages;

using FluentValidation;
using FluentValidation.Results;

namespace CoursePlatform.Identity.Application.Commands.Roles;

public class UpdateRoleCommand(Guid id, string name, Guid concurrencyStamp) : Command(id)
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public Guid ConcurrencyStamp { get; } = concurrencyStamp;

    public override ValidationResult GetValidationResult()
    {
        return new UpdateRoleValidation().Validate(this);
    }

    private class UpdateRoleValidation : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleValidation()
        {
            RuleFor(role => role.Id)
                .NotEmpty()
                .WithMessage("The id must be provided.");

            RuleFor(role => role.Name)
                .NotEmpty()
                .WithMessage("The name must be provided.")
                .MaximumLength(50)
                .WithMessage("The name must be a maximum of 50 characters.");

            RuleFor(role => role.ConcurrencyStamp)
                .NotEmpty()
                .WithMessage("The concurrency stamp must be provided.");
        }
    }
}
