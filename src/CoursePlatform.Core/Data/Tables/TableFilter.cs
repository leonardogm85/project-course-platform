namespace CoursePlatform.Core.Data.Tables;

public sealed class TableFilter
{
    public int Start { get; }
    public int Length { get; }
    public TableSort Sort { get; }
    public IEnumerable<TableSearch> Searches { get; }

    public TableFilter(int start, int length, TableSort sort, IEnumerable<TableSearch> searches)
    {
        Start = start;
        Length = length;
        Sort = sort;
        Searches = searches;
    }
}
