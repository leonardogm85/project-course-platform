namespace CoursePlatform.Core.Data.Selects;

public sealed class SelectResult
{
    public int RecordsFiltered { get; }
    public IDictionary<Guid, string> Data { get; }

    public SelectResult(int recordsFiltered, IDictionary<Guid, string> data)
    {
        RecordsFiltered = recordsFiltered;
        Data = data;
    }
}
