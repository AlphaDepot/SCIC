using System.Globalization;
using System.Windows.Data;

namespace SCIC.Converters;

public class ResponsiveWidthConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[0] is double actualWidth)
        {
            // Return 100% of the width if <= 400, otherwise return 50% of the width
            return actualWidth <= 400 ? actualWidth : actualWidth * 0.5;
        }
        return values[0]; // Default fallback to 100% of the window width
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}