using System.Security.Claims;

using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class RoleClaim : Entity
{
    public Guid RoleId { get; }
    public string ClaimType { get; } = null!;
    public string ClaimValue { get; } = null!;
    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }

    public Role? Role { get; }

    protected RoleClaim()
    {
    }

    public RoleClaim(Guid roleId, string claimType, string claimValue, Guid createdBy)
    {
        RoleId = roleId;
        ClaimType = claimType;
        ClaimValue = claimValue;

        CreatedBy = createdBy;

        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Claim ToClaim() => new(ClaimType, ClaimValue);
}
