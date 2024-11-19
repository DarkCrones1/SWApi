using SW.Common.Entities;

namespace SW.Domain.Entities;

public partial class UserDataCommend : BaseEntity
{
    public int UserDataId { get; set; }

    public int UserCommendId { get; set; }

    public virtual UserData UserData{ get; set; } = null!;

    public virtual UserCommend UserCommend{ get; set; } = null!;

}