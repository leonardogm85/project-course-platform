using CoursePlatform.Identity.Domain.Enums;

namespace CoursePlatform.Identity.Domain.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class MenuAttribute(Menu menu) : Attribute
{
    public Menu Menu { get; } = menu;
}
