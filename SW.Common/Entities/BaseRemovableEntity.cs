using SW.Common.Interfaces.Entities;

namespace SW.Common.Entities;

public abstract class BaseRemovableEntity : BaseEntity, IRemovableEntity
{
    public bool? IsDeleted { get; set; }
}