namespace ContactManager.Contracts.Filters;

public class PaginationFilter
{
    private const int maxPageSize = 10;
    private int pageSize = 5;

    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get => pageSize;
        set => pageSize = value > maxPageSize ? maxPageSize : value;
    }
}
