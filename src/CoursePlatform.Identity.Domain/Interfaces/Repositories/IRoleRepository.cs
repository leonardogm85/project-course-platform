using CoursePlatform.Core.Data;
using CoursePlatform.Identity.Domain.DataTransferObjects.Roles;
using CoursePlatform.Identity.Domain.Entities;

namespace CoursePlatform.Identity.Domain.Interfaces.Repositories;

public interface IRoleRepository : IRepository<Role>, ITableRepository<GetRolesByFilter>, ISelectRepository
{
    void AddRole(Role role);
    void UpdateRole(Role role);
    void RemoveRole(Role role);

    void AddClaim(RoleClaim claim);
    void RemoveClaim(RoleClaim claim);

    Task<Role?> GetRoleByIdAsync(Guid roleId, CancellationToken cancellationToken);

    //Task<Role?> GetClaimsByRoleIdAsync(Guid roleId, CancellationToken cancellationToken);

    //Task<bool> ExistsUsersInRoleByIdAsync(Guid roleId, CancellationToken cancellationToken);

    //Task<GetRoleById?> GetRoleByIdAsDataTransferObjectAsync(Guid roleId, CancellationToken cancellationToken);
    //Task<IEnumerable<GetClaimsByRoleId>> GetClaimsByRoleIdAsDataTransferObjectAsync(Guid roleId, CancellationToken cancellationToken);
    //Task<IEnumerable<GetMenuByRoleId>> GetMenuByRoleIdAsDataTransferObjectAsync(Guid roleId, CancellationToken cancellationToken);
}
