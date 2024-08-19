namespace CoursePlatform.Api.Settings;

public class InfoSettings
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required ContactSettings Contact { get; init; }
    public required LicenseSettings License { get; init; }

    public InfoSettings()
    {
    }

    public InfoSettings(string title, string description, ContactSettings contact, LicenseSettings license)
    {
        Title = title;
        Description = description;
        Contact = contact;
        License = license;
    }
}
