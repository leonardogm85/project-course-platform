using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoursePlatform.Identity.Data.Converters;

public class AccessConverter : ValueConverter<Domain.Enums.Access, Domain.ValueTypes.Access>
{
    public AccessConverter()
        : base(
            convertTo => (Domain.ValueTypes.Access)convertTo,
            convertFrom => (Domain.Enums.Access)convertFrom)
    {
    }
}
