using CoursePlatform.Core.Data;
using CoursePlatform.Core.Data.Selects;
using CoursePlatform.Core.Data.Tables;
using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.DataTransferObjects.Users;
using CoursePlatform.Identity.Domain.Interfaces.Repositories;

namespace CoursePlatform.Identity.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IdentityContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public UserRepository(IdentityContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<TableResult<GetUsersByFilter>> GetTableAsync(TableFilter filter, CancellationToken cancellationToken)
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
