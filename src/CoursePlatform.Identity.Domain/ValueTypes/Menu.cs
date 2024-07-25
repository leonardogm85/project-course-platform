using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.Attributes;
using CoursePlatform.Identity.Domain.Extensions;

namespace CoursePlatform.Identity.Domain.ValueTypes;

public class Menu : IValueType
{
    private readonly List<MenuItem> _menuItems = [];

    public int Id { get; }
    public string Name { get; } = null!;
    public int Order { get; }

    public IReadOnlyCollection<MenuItem> MenuItems => _menuItems.AsReadOnly();

    protected Menu()
    {
    }

    public Menu(Enums.Menu menu)
    {
        Id = menu
            .GetValue();

        Name = menu
            .GetAttribute<NameAttribute>()
            .Name;

        Order = menu
            .GetAttribute<OrderAttribute>()
            .Order;
    }

    public static implicit operator Menu(Enums.Menu menu) => new(menu);

    public static implicit operator Enums.Menu(Menu menu) => (Enums.Menu)menu.Id;
}
