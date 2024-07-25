using System.Reflection;

namespace CoursePlatform.Identity.Domain.Extensions;

public static class EnumExtensions
{
    public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
    {
        return value
            .GetType()
            .GetField(value.ToString())!
            .GetCustomAttribute<TAttribute>()!;
    }

    public static int GetValue(this Enum value) => (int)(object)value;

    public static IEnumerable<TEnum> GetAll<TEnum>() where TEnum : struct, Enum => Enum.GetValues<TEnum>();
}
