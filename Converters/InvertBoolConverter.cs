using System.Globalization;

namespace Quadro_de_pendencias.Converters;

public class InvertBoolConverter : IValueConverter
{
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return !(bool)value;
    }

    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return !(bool)value;
    }
}