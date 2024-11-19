using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Entities;

public interface ICatalogBaseEntity : IBaseQueryable
{
    public string Name { get; set; }

    public string? Description { get; set; }
}