namespace SW.Domain.Dto.Request.Create;

public class DataDreamCreateRequestDto
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public short SleepQualityStatus { get; set; }

    public int? AverageHearthRate { get; set; }

    public double? AverageOxygenLevel { get; set; }

    public double? DeepSleepHours { get; set; }

    public int? Interruptions { get; set; }
}