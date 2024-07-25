namespace CoursePlatform.Identity.Domain.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class RouteAttribute(string route) : Attribute
{
    public string Route { get; } = route;
}
