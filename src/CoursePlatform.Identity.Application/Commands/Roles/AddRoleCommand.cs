using CoursePlatform.Core.Messages;

using FluentValidation;
using FluentValidation.Results;

namespace CoursePlatform.Identity.Application.Commands.Roles;

public class AddRoleCommand(string name) : Command(Guid.NewGuid())
{
    public string Name { get; } = name;

    public override ValidationResult GetValidationResult()
    {
        return new AddRoleValidation().Validate(this);
    }

    private class AddRoleValidation : AbstractValidator<AddRoleCommand>
    {
        public AddRoleValidation()
        {
            RuleFor(role => role.Name)
                .NotEmpty()
                .WithMessage("The name must be provided.")
                .MaximumLength(50)
                .WithMessage("The name must be a maximum of 50 characters.");
        }
    }
}
