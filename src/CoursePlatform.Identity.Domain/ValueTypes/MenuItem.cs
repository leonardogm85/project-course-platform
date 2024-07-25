using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.Attributes;
using CoursePlatform.Identity.Domain.Extensions;

namespace CoursePlatform.Identity.Domain.ValueTypes;

public class MenuItem : IValueType
{
    public int Id { get; }
    public string Name { get; } = null!;
    public int Order { get; }
    public string Route { get; } = null!;
    public int MenuId { get; }

    public Menu? Menu { get; }

    protected MenuItem()
    {
    }

    public MenuItem(Enums.MenuItem menuItem)
    {
        Id = menuItem
            .GetValue();

        Name = menuItem
            .GetAttribute<NameAttribute>()
            .Name;

        Order = menuItem
            .GetAttribute<OrderAttribute>()
            .Order;

        Route = menuItem
            .GetAttribute<RouteAttribute>()
            .Route;

        MenuId = menuItem
            .GetAttribute<MenuAttribute>()
            .Menu
            .GetValue();
    }

    public static implicit operator MenuItem(Enums.MenuItem menuItem) => new(menuItem);

    public static implicit operator Enums.MenuItem(MenuItem menuItem) => (Enums.MenuItem)menuItem.Id;
}
