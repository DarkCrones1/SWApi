using SW.Common.Entities;

namespace SW.Domain.Entities;

public partial class UserCommend : CatalogBaseAuditablePaginationEntity
{
    public Guid Code {get; set;}

    public short SleepQualityStatus {get; set;}

    public virtual ICollection<UserDataCommend> UserDataCommend { get; set; } = new List<UserDataCommend>();
}