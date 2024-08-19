namespace CoursePlatform.Api.Settings;

public class LicenseSettings
{
    public required string Name { get; init; }
    public required string Url { get; init; }

    public LicenseSettings()
    {
    }

    public LicenseSettings(string name, string url)
    {
        Name = name;
        Url = url;
    }
}
