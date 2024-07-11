using FluentValidation.Results;

using MediatR;

namespace CoursePlatform.Core.Messages;

public abstract class Command : Message, IRequest<bool>
{
    public DateTimeOffset Timestamp { get; }

    protected Command(Guid aggregateId) : base(aggregateId)
    {
        Timestamp = DateTimeOffset.UtcNow;
    }

    public abstract ValidationResult GetValidationResult();
}
