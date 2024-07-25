using System.Security.Claims;

using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.ValueTypes;

namespace CoursePlatform.Identity.Domain.Entities;

public class RoleClaim : Entity
{
    public Guid RoleId { get; }
    public MenuItem ClaimType { get; } = null!;
    public ItemAccess ClaimValue { get; } = null!;
    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }

    public Role? Role { get; }

    protected RoleClaim()
    {
    }

    public RoleClaim(Guid roleId, MenuItem claimType, ItemAccess claimValue, Guid createdBy)
    {
        RoleId = roleId;
        ClaimType = claimType;
        ClaimValue = claimValue;

        CreatedBy = createdBy;

        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Claim ToClaim() => new(ClaimType.Id.ToString(), ClaimValue.Id.ToString());
}
