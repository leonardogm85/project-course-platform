using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoursePlatform.Identity.Data.Converters;

public class ItemAccessConverter : ValueConverter<Domain.Enums.ItemAccess, Domain.ValueTypes.ItemAccess>
{
    public ItemAccessConverter()
        : base(
            convertTo => (Domain.ValueTypes.ItemAccess)convertTo,
            convertFrom => (Domain.Enums.ItemAccess)convertFrom)
    {
    }
}
