using CoursePlatform.Identity.Domain.Attributes;

namespace CoursePlatform.Identity.Domain.Enums;

public enum ItemAccess
{
    [Name("Create")]
    Create = 1,

    [Name("Read")]
    Read = 2,

    [Name("Update")]
    Update = 3,

    [Name("Delete")]
    Delete = 4
}
