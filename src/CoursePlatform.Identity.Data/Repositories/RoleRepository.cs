using CoursePlatform.Core.Data;
using CoursePlatform.Core.Data.Selects;
using CoursePlatform.Core.Data.Tables;
using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.DataTransferObjects.Roles;
using CoursePlatform.Identity.Domain.Interfaces.Repositories;

namespace CoursePlatform.Identity.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IdentityContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public RoleRepository(IdentityContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<TableResult<GetRolesByFilter>> GetTableAsync(TableFilter filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SelectResult> GetSelectAsync(SelectFilter filter, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SelectResult> GetSelectAsync(IEnumerable<Guid> identities, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
