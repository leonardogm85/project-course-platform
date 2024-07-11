using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class UserLogin : Entity
{
    public Guid UserId { get; }
    public string LoginProvider { get; } = null!;
    public string ProviderKey { get; } = null!;
    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }

    public User? User { get; }

    protected UserLogin()
    {
    }

    public UserLogin(Guid userId, string loginProvider, string providerKey, Guid createdBy)
    {
        UserId = userId;
        LoginProvider = loginProvider;
        ProviderKey = providerKey;

        CreatedBy = createdBy;

        CreatedAt = DateTimeOffset.UtcNow;
    }
}
