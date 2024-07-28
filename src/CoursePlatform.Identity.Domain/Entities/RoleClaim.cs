using System.Security.Claims;

using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.ValueTypes;

namespace CoursePlatform.Identity.Domain.Entities;

public class RoleClaim : Entity
{
    public Guid RoleId { get; }
    public Submenu Submenu { get; } = null!;
    public Access Access { get; } = null!;
    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }

    public Role? Role { get; }

    protected RoleClaim()
    {
    }

    public RoleClaim(Guid roleId, Submenu submenu, Access access, Guid createdBy)
    {
        RoleId = roleId;
        Submenu = submenu;
        Access = access;

        CreatedBy = createdBy;

        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Claim ToClaim() => new(Submenu.Id.ToString(), Access.Id.ToString());
}
