using SW.Common.Entities;

namespace SW.Domain.Entities;

public partial class DataDream : BaseAuditablePaginationEntity
{
    public Guid Code { get; set; }

    public int UserDataId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int DurationMinutes => (int)(EndTime - StartTime).TotalMinutes;

    public short SleepQualityStatus { get; set; }

    public int? AverageHearthRate { get; set; }

    public double? AverageOxygenLevel { get; set; }

    public double? DeepSleepHours { get; set; }

    public int? Interruptions { get; set; }

    public virtual UserData UserData { get; set; } = null!;
}