using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.Attributes;
using CoursePlatform.Identity.Domain.Extensions;

namespace CoursePlatform.Identity.Domain.ValueTypes;

public class Menu : IValueType
{
    private readonly List<Submenu> _submenus = [];

    public int Id { get; }
    public string Name { get; } = null!;
    public int Order { get; }

    public IReadOnlyCollection<Submenu> Submenus => _submenus.AsReadOnly();

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
