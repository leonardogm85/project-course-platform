using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class Role : Entity, IAggregateRoot
{
    private readonly List<User> _users = [];
    private readonly List<RoleClaim> _claims = [];

    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public DateTime UpdatedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid UpdatedBy { get; private set; }
    public Guid CreatedBy { get; private set; }
    public bool Active { get; private set; }
    public Guid ConcurrencyStamp { get; private set; }

    public IReadOnlyCollection<User> Users => _users.AsReadOnly();
    public IReadOnlyCollection<RoleClaim> Claims => _claims.AsReadOnly();

    protected Role()
    {
    }

    public Role(string name, string description, Guid createdBy)
    {
        Name = name;
        Description = description;

        CreatedBy = createdBy;
        UpdatedBy = createdBy;

        UpdatedAt = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;

        Active = true;

        ConcurrencyStamp = Guid.NewGuid();
    }

    public void SetName(string name) => Name = name;
    public void SetDescription(string description) => Description = description;

    public void EntityUpdatedAt() => UpdatedAt = DateTime.UtcNow;
    public void EntityUpdatedBy(Guid user) => UpdatedBy = user;

    public void Activate() => Active = true;
    public void Deactivate() => Active = false;
}
