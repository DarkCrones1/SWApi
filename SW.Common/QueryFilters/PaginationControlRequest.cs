using SW.Common.Interfaces.Entities;

namespace SW.Common.QueryFilters;

public abstract class PaginationControlRequestFilter : IPaginationQueryable
{
    public int PageSize { get; set; } = 15;
    public int PageNumber { get; set; } = 1;
}