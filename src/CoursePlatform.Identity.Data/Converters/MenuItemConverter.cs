using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoursePlatform.Identity.Data.Converters;

public class MenuItemConverter : ValueConverter<Domain.Enums.MenuItem, Domain.ValueTypes.MenuItem>
{
    public MenuItemConverter()
        : base(
            convertTo => (Domain.ValueTypes.MenuItem)convertTo,
            convertFrom => (Domain.Enums.MenuItem)convertFrom)
    {
    }
}
