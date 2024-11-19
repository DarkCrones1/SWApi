using SW.Common.Interfaces.Entities;

namespace SW.Common.Entities;

public abstract class BaseRemovableAuditableEntity : BaseAuditableEntity, IRemovableEntity
{
    public bool? IsDeleted { get; set; }
}