using CoursePlatform.Core.Data;
using CoursePlatform.Core.Data.Selects;
using CoursePlatform.Core.Data.Tables;
using CoursePlatform.Identity.Data.Context;
using CoursePlatform.Identity.Domain.DataTransferObjects.Roles;
using CoursePlatform.Identity.Domain.Entities;
using CoursePlatform.Identity.Domain.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

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

    public void AddRole(Role role) => _context.Roles.Add(role);
    public void UpdateRole(Role role) => _context.Roles.Update(role);
    public void RemoveRole(Role role) => _context.Roles.Remove(role);

    public void AddClaim(RoleClaim claim) => _context.RoleClaims.Add(claim);
    public void RemoveClaim(RoleClaim claim) => _context.RoleClaims.Remove(claim);

    public async Task<Role?> GetRoleByIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await _context
            .Roles
            .FirstOrDefaultAsync(role => role.Id == roleId, cancellationToken);
    }

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
