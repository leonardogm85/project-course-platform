using CoursePlatform.Core.Data.Selects;

namespace CoursePlatform.Core.Data;

public interface ISelectRepository
{
    Task<SelectResult> GetSelectAsync(SelectFilter filter, CancellationToken cancellationToken);
    Task<SelectResult> GetSelectAsync(IEnumerable<Guid> identities, CancellationToken cancellationToken);
}
