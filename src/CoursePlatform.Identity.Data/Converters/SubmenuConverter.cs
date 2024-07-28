using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoursePlatform.Identity.Data.Converters;

public class SubmenuConverter : ValueConverter<Domain.Enums.Submenu, Domain.ValueTypes.Submenu>
{
    public SubmenuConverter()
        : base(
            convertTo => (Domain.ValueTypes.Submenu)convertTo,
            convertFrom => (Domain.Enums.Submenu)convertFrom)
    {
    }
}
