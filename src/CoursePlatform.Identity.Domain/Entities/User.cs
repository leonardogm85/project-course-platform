using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class User : Entity, IAggregateRoot
{
    private readonly List<Role> _roles = [];
    private readonly List<UserClaim> _claims = [];

    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public bool EmailConfirmed { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    public string PasswordHash { get; private set; } = null!;
    public string SecurityStamp { get; private set; } = null!;
    public bool TwoFactorEnabled { get; private set; }
    public DateTime? LockoutEnd { get; private set; }
    public bool LockoutEnabled { get; private set; }
    public int AccessFailedCount { get; private set; }
    public bool Administrator { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid UpdatedBy { get; private set; }
    public Guid CreatedBy { get; private set; }
    public bool Active { get; private set; }
    public Guid ConcurrencyStamp { get; private set; }

    public IReadOnlyCollection<Role> Users => _roles.AsReadOnly();
    public IReadOnlyCollection<UserClaim> Claims => _claims.AsReadOnly();

    protected User()
    {
    }

    public User(string name, string email, string phoneNumber, string passwordHash, string securityStamp, bool twoFactorEnabled, Guid createdBy)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
        SecurityStamp = securityStamp;
        TwoFactorEnabled = twoFactorEnabled;

        CreatedBy = createdBy;
        UpdatedBy = createdBy;

        UpdatedAt = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;

        Active = true;

        ConcurrencyStamp = Guid.NewGuid();
    }

    public void SetName(string name) => Name = name;

    public void SetEmail(string email)
    {
        Email = email;
        EmailConfirmed = false;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        PhoneNumberConfirmed = false;
    }

    public void ConfirmEmail() => EmailConfirmed = true;
    public void ConfirmPhoneNumber() => PhoneNumberConfirmed = true;

    //string PasswordHash
    //DateTime? LockoutEnd
    //bool LockoutEnabled
    //int AccessFailedCount

    public void EnableTwoFactor() => TwoFactorEnabled = true;
    public void DisableTwoFactor() => TwoFactorEnabled = false;

    public void EntityUpdatedAt() => UpdatedAt = DateTime.UtcNow;
    public void EntityUpdatedBy(Guid user) => UpdatedBy = user;

    public void Activate() => Active = true;
    public void Deactivate() => Active = false;
}
