using SW.Common.Entities;

namespace SW.Domain.Entities;

public partial class ActiveUserAccount : BaseQueryable
{
    public string UserName { get; set; } = null!;

    public int UserDataId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string CellPhone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public short UserAccountType { get; set; }

    public string Name => $"{this.FirstName} {this.MiddleName} {this.LastName}".Trim();
}