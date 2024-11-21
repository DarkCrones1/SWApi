namespace SW.Domain.Dto.Request.Update;

public class UserDataUpdateRequestDto
{
    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string CellPhone { get; set; } = null!;

    public short? Gender { get; set; }

    public DateTime? BirthDate { get; set; }
}