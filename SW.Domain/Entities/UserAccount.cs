using SW.Common.Entities;

namespace SW.Domain.Entities;

public partial class UserAccount : BaseRemovablePaginationEntity
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsAuthorized { get; set; }

    public short UserAccountType { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<UserData> UserData { get; } = new List<UserData>();
}