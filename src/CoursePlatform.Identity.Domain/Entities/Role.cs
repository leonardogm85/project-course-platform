using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class Role : Entity, IAggregateRoot
{
    private readonly List<User> _users = [];
    private readonly List<RoleClaim> _claims = [];

    public string Name { get; private set; } = null!;
    public DateTimeOffset UpdatedAt { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public Guid UpdatedBy { get; private set; }
    public Guid CreatedBy { get; private set; }
    public bool Active { get; private set; }
    public Guid ConcurrencyStamp { get; private set; }

    public IReadOnlyCollection<User> Users => _users.AsReadOnly();
    public IReadOnlyCollection<RoleClaim> Claims => _claims.AsReadOnly();

    protected Role()
    {
    }

    public Role(string name, Guid createdBy)
    {
        Name = name;

        CreatedBy = createdBy;
        UpdatedBy = createdBy;

        UpdatedAt = DateTimeOffset.UtcNow;
        CreatedAt = DateTimeOffset.UtcNow;

        Active = true;

        ConcurrencyStamp = Guid.NewGuid();
    }

    public void SetName(string name) => Name = name;

    public void EntityUpdatedBy(Guid user)
    {
        UpdatedBy = user;

        UpdatedAt = DateTimeOffset.UtcNow;

        ConcurrencyStamp = Guid.NewGuid();
    }

    public void Activate() => Active = true;
    public void Deactivate() => Active = false;
}
