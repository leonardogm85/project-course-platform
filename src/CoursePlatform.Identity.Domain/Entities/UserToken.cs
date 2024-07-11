using CoursePlatform.Core.Domain;

namespace CoursePlatform.Identity.Domain.Entities;

public class UserToken : Entity
{
    public Guid UserId { get; }
    public string LoginProvider { get; } = null!;
    public string TokenName { get; } = null!;
    public string TokenValue { get; } = null!;
    public DateTimeOffset CreatedAt { get; }
    public Guid CreatedBy { get; }

    public User? User { get; }

    protected UserToken()
    {
    }

    public UserToken(Guid userId, string loginProvider, string tokenName, string tokenValue, Guid createdBy)
    {
        UserId = userId;
        LoginProvider = loginProvider;
        TokenName = tokenName;
        TokenValue = tokenValue;

        CreatedBy = createdBy;

        CreatedAt = DateTimeOffset.UtcNow;
    }
}
