using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class UserRole : Entity
{
    public Guid UserId { get; }
    public Guid RoleId { get; }
    public DateTime CreatedAt { get; }
    public Guid CreatedBy { get; }

    public User? User { get; }
    public Role? Role { get; }

    protected UserRole()
    {
    }

    public UserRole(Guid userId, Guid roleId, Guid createdBy)
    {
        UserId = userId;
        RoleId = roleId;

        CreatedBy = createdBy;

        CreatedAt = DateTime.UtcNow;
    }
}
