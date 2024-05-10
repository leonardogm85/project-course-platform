using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class RoleClaim : Entity
{
    public Guid RoleId { get; }
    public string ClaimType { get; } = null!;
    public string ClaimValue { get; } = null!;
    public DateTime CreatedAt { get; }
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

        CreatedAt = DateTime.UtcNow;
    }
}
