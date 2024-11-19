using SW.Common.Interfaces.Entities;

namespace SW.Common.Entities;

public abstract class BaseEntity : IBaseQueryable
{
    public int Id { get; set; }
}