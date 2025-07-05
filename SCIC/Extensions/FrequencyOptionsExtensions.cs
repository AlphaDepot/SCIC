using System.ComponentModel;
using SCIC.Enums;

namespace SCIC.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="FrequencyOptions"/> enum.
/// </summary>
public static class FrequencyOptionsExtensions
{
    public static string GetDescription(this FrequencyOptions frequency)
    {
        var fieldInfo = frequency.GetType().GetField(frequency.ToString());
        if (fieldInfo == null)
        {
            return frequency.ToString(); // Fallback if no field info is found
        }
     
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : frequency.ToString();
        
    }

    public static int GetValue(this FrequencyOptions frequency)
    {
        return (int)frequency;
    }
    
    public static FrequencyOptions FromDescription(string description)
    {
        foreach (var option in Enum.GetValues<FrequencyOptions>())
        {
            if (option.GetDescription() == description)
            {
                return option;
            }
        }
        throw new ArgumentException($"No FrequencyOptions found for description: {description}");
    }
   
}