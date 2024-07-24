using CoursePlatform.Core.Domain;

namespace CoursePlatform.Core.Data.Tables;

public sealed class TableResult<TData> where TData : IDataTransferObject
{
    public int RecordsTotal { get; }
    public int RecordsFiltered { get; }
    public IEnumerable<TData> Data { get; }

    public TableResult(int recordsTotal, int recordsFiltered, IEnumerable<TData> data)
    {
        RecordsTotal = recordsTotal;
        RecordsFiltered = recordsFiltered;
        Data = data;
    }
}
