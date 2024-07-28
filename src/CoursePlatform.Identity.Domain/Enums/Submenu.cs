using CoursePlatform.Identity.Domain.Attributes;
using CoursePlatform.Identity.Domain.Constants;

namespace CoursePlatform.Identity.Domain.Enums;

public enum Submenu
{
    [Name("Users")]
    [Order(1)]
    [Route(Routes.Users)]
    [Menu(Menu.Identity)]
    Users = 1,

    [Name("Roles")]
    [Order(2)]
    [Route(Routes.Roles)]
    [Menu(Menu.Identity)]
    Roles = 2
}
