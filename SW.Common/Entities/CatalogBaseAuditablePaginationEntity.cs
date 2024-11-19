using System.ComponentModel.DataAnnotations.Schema;
using SW.Common.Interfaces.Entities;

namespace SW.Common.Entities;

public abstract class CatalogBaseAuditablePaginationEntity : CatalogBaseAuditableEntity, IPaginationQueryable
{
    [NotMapped]
    public int PageSize { get; set; }

    [NotMapped]
    public int PageNumber { get; set; }
}