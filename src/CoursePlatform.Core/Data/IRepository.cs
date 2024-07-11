using CoursePlatform.Core.Domain;

namespace CoursePlatform.Core.Data;

public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
