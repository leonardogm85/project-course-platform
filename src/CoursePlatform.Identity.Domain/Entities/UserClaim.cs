using System.Security.Claims;

using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class UserClaim : Entity
{
    public Guid UserId { get; }
    public string ClaimType { get; } = null!;
    public string ClaimValue { get; } = null!;
    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }

    public User? User { get; }

    protected UserClaim()
    {
    }

    public UserClaim(Guid userId, string claimType, string claimValue, Guid createdBy)
    {
        UserId = userId;
        ClaimType = claimType;
        ClaimValue = claimValue;

        CreatedBy = createdBy;

        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Claim ToClaim() => new(ClaimType, ClaimValue);
}
