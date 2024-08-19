namespace CoursePlatform.Api.Settings;

public class ContactSettings
{
    public required string Name { get; init; }
    public required string Url { get; init; }

    public ContactSettings()
    {
    }

    public ContactSettings(string name, string url)
    {
        Name = name;
        Url = url;
    }
}
