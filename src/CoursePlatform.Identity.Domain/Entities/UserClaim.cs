using System.Security.Claims;

using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.ValueTypes;

namespace CoursePlatform.Identity.Domain.Entities;

public class UserClaim : Entity
{
    public Guid UserId { get; }
    public Submenu Submenu { get; } = null!;
    public Access Access { get; } = null!;
    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }

    public User? User { get; }

    protected UserClaim()
    {
    }

    public UserClaim(Guid userId, Submenu submenu, Access access, Guid createdBy)
    {
        UserId = userId;
        Submenu = submenu;
        Access = access;

        CreatedBy = createdBy;

        CreatedAt = DateTimeOffset.UtcNow;
    }

    public Claim ToClaim() => new(Submenu.Id.ToString(), Access.Id.ToString());
}
