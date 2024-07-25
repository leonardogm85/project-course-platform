using CoursePlatform.Core.Data;
using CoursePlatform.Identity.Domain.DataTransferObjects;
using CoursePlatform.Identity.Domain.Entities;

namespace CoursePlatform.Identity.Domain.Interfaces.Repositories;

public interface IRoleRepository : IRepository<Role>, ITableRepository<GetRolesByFilter>, ISelectRepository
{
    Task AddRoleAsync(Role role, CancellationToken cancellationToken);
    Task UpdateRoleAsync(Role role, CancellationToken cancellationToken);
    Task RemoveRoleAsync(Role role, CancellationToken cancellationToken);

    Task<Role?> GetRoleByIdAsync(Guid roleId, CancellationToken cancellationToken);

    Task AddClaimAsync(RoleClaim claim, CancellationToken cancellationToken);
    Task RemoveClaimAsync(RoleClaim claim, CancellationToken cancellationToken);

    Task<IEnumerable<GetClaimsByRoleId>> GetClaimsByRoleIdAsync(Guid roleId, CancellationToken cancellationToken);

    Task<bool> ExistsUsersInRoleByIdAsync(Guid roleId, CancellationToken cancellationToken);

    Task<IEnumerable<GetMenuByRoleId>> GetMenuByRoleIdAsync(Guid roleId, CancellationToken cancellationToken);
}
