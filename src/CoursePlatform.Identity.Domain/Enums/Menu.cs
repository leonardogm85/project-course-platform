using CoursePlatform.Identity.Domain.Attributes;

namespace CoursePlatform.Identity.Domain.Enums;

public enum Menu
{
    [Name("Identity")]
    [Order(1)]
    Identity = 1,

    [Name("Catalog")]
    [Order(2)]
    Catalog = 2
}
