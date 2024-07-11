using System.Linq.Expressions;

using CoursePlatform.Identity.Data.Settings;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;

namespace CoursePlatform.Identity.Data.Converters;

public class PersonalDataConverter : ValueConverter<string, string>
{
    public PersonalDataConverter(IDataProtectionProvider provider, IOptions<IdentitySettings> settings)
        : this(PersonalDataProtector.Create(provider, settings))
    {
    }

    private PersonalDataConverter(PersonalDataProtector protector)
        : base(protector.ConvertTo, protector.ConvertFrom)
    {
    }

    private class PersonalDataProtector
    {
        private readonly IDataProtector _dataProtector;

        private PersonalDataProtector(IDataProtectionProvider provider, IOptions<IdentitySettings> settings)
        {
            _dataProtector = provider.CreateProtector(settings.Value.SecretKey);
        }

        public static PersonalDataProtector Create(IDataProtectionProvider provider, IOptions<IdentitySettings> settings)
        {
            return new(provider, settings);
        }

        public Expression<Func<string, string>> ConvertTo => value => _dataProtector.Protect(value);

        public Expression<Func<string, string>> ConvertFrom => value => _dataProtector.Unprotect(value);
    }
}
