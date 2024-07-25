namespace CoursePlatform.Identity.Domain.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class OrderAttribute(int order) : Attribute
{
    public int Order { get; } = order;
}
