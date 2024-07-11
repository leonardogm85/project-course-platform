namespace CoursePlatform.Identity.Data.Settings;

public class IdentitySettings
{
    public required string SecretKey { get; init; } = null!;

    public IdentitySettings()
    {
    }

    public IdentitySettings(string secretKey)
    {
        SecretKey = secretKey;
    }
}
