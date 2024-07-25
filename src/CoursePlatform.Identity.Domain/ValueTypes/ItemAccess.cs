using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.Attributes;
using CoursePlatform.Identity.Domain.Extensions;

namespace CoursePlatform.Identity.Domain.ValueTypes;

public class ItemAccess : IValueType
{
    public int Id { get; }
    public string Name { get; } = null!;

    protected ItemAccess()
    {
    }

    public ItemAccess(Enums.ItemAccess itemAccess)
    {
        Id = itemAccess
            .GetValue();

        Name = itemAccess
            .GetAttribute<NameAttribute>()
            .Name;
    }

    public static implicit operator ItemAccess(Enums.ItemAccess itemAccess) => new(itemAccess);

    public static implicit operator Enums.ItemAccess(ItemAccess itemAccess) => (Enums.ItemAccess)itemAccess.Id;
}
