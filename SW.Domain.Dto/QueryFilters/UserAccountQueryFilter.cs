using SW.Common.Interfaces.Entities;
using SW.Common.QueryFilters;

namespace SW.Domain.Dto.QueryFilters;

public class UserAccountQueryFilter : PaginationControlRequestFilter, IBaseQueryFilter
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public bool? IsDeleted { get; set; }
}