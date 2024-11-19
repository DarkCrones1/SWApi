using System.ComponentModel;

namespace SW.Domain.Enumerations;

public enum UserAccountType
{
    [Description("Gratis")]
    Free = 1,
    [Description("Pago")]
    Premium = 2
}