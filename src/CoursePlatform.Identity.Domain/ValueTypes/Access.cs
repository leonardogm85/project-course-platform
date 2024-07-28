using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.Attributes;
using CoursePlatform.Identity.Domain.Extensions;

namespace CoursePlatform.Identity.Domain.ValueTypes;

public class Access : IValueType
{
    public int Id { get; }
    public string Name { get; } = null!;

    protected Access()
    {
    }

    public Access(Enums.Access access)
    {
        Id = access
            .GetValue();

        Name = access
            .GetAttribute<NameAttribute>()
            .Name;
    }

    public static implicit operator Access(Enums.Access access) => new(access);

    public static implicit operator Enums.Access(Access access) => (Enums.Access)access.Id;
}
