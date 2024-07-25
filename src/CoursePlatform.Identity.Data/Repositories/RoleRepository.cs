using CoursePlatform.Core.Data;
using CoursePlatform.Identity.Data.Context;

//using CoursePlatform.Identity.Domain.Interfaces.Repositories;

namespace CoursePlatform.Identity.Data.Repositories;

public class RoleRepository //: IRoleRepository
{
    private readonly IdentityContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public RoleRepository(IdentityContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();
}
