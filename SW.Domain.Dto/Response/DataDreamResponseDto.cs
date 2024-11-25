namespace SW.Domain.Dto.Response;

public class DataDreamResponseDto
{
    public int Id { get; set; }

    public Guid Code { get; set; }

    public int UserDataId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int DurationMinutes => (int)(EndTime - StartTime).TotalMinutes;

    public short SleepQualityStatus { get; set; }

    public string SleepQualityStatusName { get; set; } = string.Empty;

    public int? AverageHearthRate { get; set; }

    public double? AverageOxygenLevel { get; set; }

    public double? DeepSleepHours { get; set; }

    public int? Interruptions { get; set; }
}