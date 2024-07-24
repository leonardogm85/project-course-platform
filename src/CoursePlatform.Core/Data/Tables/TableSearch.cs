namespace CoursePlatform.Core.Data.Tables;

public sealed class TableSearch
{
    public string Column { get; }
    public string Value { get; }

    public TableSearch(string column, string value)
    {
        Column = column;
        Value = value;
    }
}
