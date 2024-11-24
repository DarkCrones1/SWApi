namespace SW.Domain.Dto.Response;

public class UserCommendResponseDto : BaseCatalogResponseDto
{
    public Guid Code {get; set;}

    public short SleepQualityStatus {get; set;}

    public string SleepQualityStatusName {get; set;} = string.Empty;
}