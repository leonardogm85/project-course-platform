namespace CoursePlatform.Core.Data.Tables;

public sealed class TableSort
{
    public string Column { get; }
    public TableDirection Direction { get; }

    public TableSort(string column, TableDirection direction)
    {
        Column = column;
        Direction = direction;
    }
}
