using System.ComponentModel;

namespace SCIC.Enums;

/// <summary>
/// Specifies the available frequency options for various operations,
/// such as financial calculations or scheduling, each representing a
/// specific number of occurrences in a year.
/// </summary>
public enum FrequencyOptions
{
    [Description("Annual")]
    Annual = 1,
    [Description("Semi-Annual")]
    SemiAnnual = 2,
    [Description("Quarterly")]
    Quarterly = 4,
    [Description("Bi-Monthly")]
    BiMonthly = 6,
    [Description("Monthly")]
    Monthly = 12,
    [Description("Semi-Monthly")]
    SemiMonthly = 24,
    [Description("Bi-Weekly")]
    BiWeekly = 26,
    [Description("Weekly")]
    Weekly = 52,
    [Description("Daily")]
    Daily = 365
}