using SW.Common.Entities;

namespace SW.Domain.Entities;

public partial class UserData : BaseRemovableAuditablePaginationEntity
{
    public Guid Code { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string CellPhone { get; set; } = null!;

    public string? Phone { get; set; } 

    public short? Gender { get; set; }

    public DateTime? BirthDate { get; set; }

    public string FullName { get => $"{FirstName} {MiddleName} {LastName}".Trim(); }

    public virtual ICollection<UserAccount> UserAccount { get; } = new List<UserAccount>();

    public virtual ICollection<UserDataCommend> UserDataCommend { get; set; } = new List<UserDataCommend>();

    public virtual ICollection<DataDream> DataDream { get; } = new List<DataDream>();

}