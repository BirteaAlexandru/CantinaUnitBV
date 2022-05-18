namespace Domain.Search;

public class SearchArgs
{
    public string SearchText { get; set; }
    public int Offset { get; set; }
    public int Limit { get; set; } = 10;
    public SortOptionArgs SortOption { get; set; }

}

public class SearchUserArgs : SearchArgs {
    public long RoleId { get; set; }
}