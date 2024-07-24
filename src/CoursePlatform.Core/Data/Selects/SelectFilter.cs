namespace CoursePlatform.Core.Data.Selects;

public sealed class SelectFilter
{
    public int Start { get; }
    public int Length { get; }
    public string Search { get; }

    public SelectFilter(int start, int length, string search)
    {
        Start = start;
        Length = length;
        Search = search;
    }
}
