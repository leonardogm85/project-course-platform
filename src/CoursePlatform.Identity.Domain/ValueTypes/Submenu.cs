using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.Attributes;
using CoursePlatform.Identity.Domain.Extensions;

namespace CoursePlatform.Identity.Domain.ValueTypes;

public class Submenu : IValueType
{
    public int Id { get; }
    public string Name { get; } = null!;
    public int Order { get; }
    public string Route { get; } = null!;
    public int MenuId { get; }

    public Menu? Menu { get; }

    protected Submenu()
    {
    }

    public Submenu(Enums.Submenu submenu)
    {
        Id = submenu
            .GetValue();

        Name = submenu
            .GetAttribute<NameAttribute>()
            .Name;

        Order = submenu
            .GetAttribute<OrderAttribute>()
            .Order;

        Route = submenu
            .GetAttribute<RouteAttribute>()
            .Route;

        MenuId = submenu
            .GetAttribute<MenuAttribute>()
            .Menu
            .GetValue();
    }

    public static implicit operator Submenu(Enums.Submenu submenu) => new(submenu);

    public static implicit operator Enums.Submenu(Submenu submenu) => (Enums.Submenu)submenu.Id;
}
