namespace CoursePlatform.Api.Settings;

public class CultureSettings
{
    public required string Name { get; init; }

    public CultureSettings()
    {
    }

    public CultureSettings(string name)
    {
        Name = name;
    }
}
