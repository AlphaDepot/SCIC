using System.Globalization;
using System.Windows.Data;

namespace SCIC.Converters;

public class GreaterThanConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return double.TryParse(value.ToString(), out var doubleValue) &&
               double.TryParse(parameter.ToString(), out var parameterValue) &&
               doubleValue > parameterValue;
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}