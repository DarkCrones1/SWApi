namespace SW.Domain.Dto.Request.Update;

public class DataDreamUpdateRequestDto
{
    public DateTime Endtime { get; set; }

    public short SleepQualityStatus { get; set; }

    public int? AverageHearthRate { get; set; }

    public double? AverageOxygenLevel { get; set; }

    public double? DeepSleepHours { get; set; }

    public int? Interruptions { get; set; }
}