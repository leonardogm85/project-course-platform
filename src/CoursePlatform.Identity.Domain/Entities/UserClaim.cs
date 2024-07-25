using System.Security.Claims;

using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.ValueTypes;

namespace CoursePlatform.Identity.Domain.Entities;

public class UserClaim : Entity
{
    public Guid UserId { get; }
    public MenuItem ClaimType { get; } = null!;
    public ItemAccess ClaimValue { get; } = null!;
    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }

    public User? User { get; }

    protected UserClaim()
    {
    }

    public UserClaim(Guid userId, MenuItem claimType, ItemAccess claimValue, Guid createdBy)
    {
        UserId = userId;
        ClaimType = claimType;
        ClaimValue = claimValue;

        CreatedBy = createdBy;

        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Claim ToClaim() => new(ClaimType.Id.ToString(), ClaimValue.Id.ToString());
}
