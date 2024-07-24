using CoursePlatform.Core.Data.Tables;
using CoursePlatform.Core.Domain;

namespace CoursePlatform.Core.Data;

public interface ITableRepository<TData> where TData : IDataTransferObject
{
    Task<TableResult<TData>> GetTableAsync(TableFilter filter, CancellationToken cancellationToken);
}
