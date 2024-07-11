using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class User : Entity, IAggregateRoot
{
    private readonly List<Role> _roles = [];
    private readonly List<UserClaim> _claims = [];
    private readonly List<UserLogin> _logins = [];
    private readonly List<UserToken> _tokens = [];

    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public bool EmailConfirmed { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    public string? PasswordHash { get; private set; }
    public string? SecurityStamp { get; private set; }
    public bool TwoFactorEnabled { get; private set; }
    public DateTimeOffset? LockoutEnd { get; private set; }
    public bool LockoutEnabled { get; private set; }
    public int AccessFailedCount { get; private set; }
    public bool Administrator { get; private set; }
    public DateTimeOffset UpdatedAt { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public Guid UpdatedBy { get; private set; }
    public Guid CreatedBy { get; private set; }
    public bool Active { get; private set; }
    public Guid ConcurrencyStamp { get; private set; }

    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();
    public IReadOnlyCollection<UserClaim> Claims => _claims.AsReadOnly();
    public IReadOnlyCollection<UserLogin> Logins => _logins.AsReadOnly();
    public IReadOnlyCollection<UserToken> Tokens => _tokens.AsReadOnly();

    protected User()
    {
    }

    public User(string name, string email, string phoneNumber, bool twoFactorEnabled, Guid createdBy)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        TwoFactorEnabled = twoFactorEnabled;

        CreatedBy = createdBy;
        UpdatedBy = createdBy;

        UpdatedAt = DateTimeOffset.UtcNow;
        CreatedAt = DateTimeOffset.UtcNow;

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

    public void EnableTwoFactor() => TwoFactorEnabled = true;
    public void DisableTwoFactor() => TwoFactorEnabled = false;

    public void EnableLockout() => LockoutEnabled = true;
    public void DisableLockout() => LockoutEnabled = false;

    public void EntityUpdatedAt() => UpdatedAt = DateTimeOffset.UtcNow;
    public void EntityUpdatedBy(Guid user) => UpdatedBy = user;

    public void Activate() => Active = true;
    public void Deactivate() => Active = false;

    public bool HasPassword()
    {
        return PasswordHash is not null
            &&
            SecurityStamp is not null;
    }

    public bool VerifyPassword(string password)
    {
        throw new NotImplementedException();
    }

    public void RemovePassword()
    {
        throw new NotImplementedException();
    }

    public void SetPassword(string password)
    {
        throw new NotImplementedException();
    }

    public void ChangePassword(string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}
