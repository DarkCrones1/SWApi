using SW.Common.Interfaces.Entities;
using SW.Common.QueryFilters;

namespace SW.Domain.Dto.QueryFilters;

public class DataDreamQueryFilter : PaginationControlRequestFilter, IBaseQueryFilter
{
    public Guid? Code { get; set; }

    public int UserDataId { get; set; }

    public DateTime? MinStartDay { get; set; }

    public DateTime? MaxEndDay { get; set; }

    public short SleepQualityStatus { get; set; }

    public int AverageHearthRate { get; set; }

    public double? AverageOxygenLevel { get; set; }

    public double? DeepSleepHours { get; set; }

    public int? Interruptions { get; set; }
}