using SW.Common.Interfaces.Entities;
using SW.Common.QueryFilters;

namespace SW.Domain.Dto.QueryFilters;

public class UserDataQueryFilter : PaginationControlRequestFilter, IBaseQueryFilter
{
    public int Id { get; set; }

    public Guid Code { get; set; }

    public string? Name { get; set; } = null!;

    public string? CellPhone { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool? IsDeleted { get; set; }
}