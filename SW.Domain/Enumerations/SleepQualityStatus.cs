using System.ComponentModel;

namespace SW.Domain.Enumerations;

public enum SleepQualityStatus
{
    [Description("Excelente")]
    Excelent = 1,

    [Description("Buena")]
    Well = 2,

    [Description("Regular")]
    Regular = 3,

    [Description("Mala")]
    Worst = 4,

}