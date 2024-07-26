using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoursePlatform.Identity.Data.Converters;

public class MenuConverter : ValueConverter<Domain.Enums.Menu, Domain.ValueTypes.Menu>
{
    public MenuConverter()
        : base(
            convertTo => (Domain.ValueTypes.Menu)convertTo,
            convertFrom => (Domain.Enums.Menu)convertFrom)
    {
    }
}
