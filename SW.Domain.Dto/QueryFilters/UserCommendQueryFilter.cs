using SW.Common.Interfaces.Entities;
using SW.Common.QueryFilters;

namespace SW.Domain.Dto.QueryFilters;

public class UserCommendQueryFilter : PaginationControlRequestFilter, IBaseQueryFilter
{
    public int Id { get; set; }

    public Guid Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public short SleepQualityStatus {get; set;}

    public bool? IsDeleted { get; set; }
}