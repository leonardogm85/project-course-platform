using CoursePlatform.Core.Domain;
using CoursePlatform.Identity.Domain.ValueTypes;

namespace CoursePlatform.Identity.Domain.ValueObjects
{
    public class Claim : IValueObject
    {
        public MenuItem ClaimType { get; }
        public ItemAccess ClaimValue { get; }

        public Claim(MenuItem claimType, ItemAccess claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
    }
}
