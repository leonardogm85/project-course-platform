using CoursePlatform.Core.Data;
using CoursePlatform.Identity.Domain.DataTransferObjects.Users;
using CoursePlatform.Identity.Domain.Entities;

namespace CoursePlatform.Identity.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>, ITableRepository<GetUsersByFilter>, ISelectRepository
{
}
