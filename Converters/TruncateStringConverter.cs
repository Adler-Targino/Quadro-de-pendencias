using System.Globalization;

namespace Quadro_de_pendencias.Converters
{
    public class TruncateStringConverter : IValueConverter
    {
        public object Convert(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            if (value is not string text)
                return string.Empty;

            int maxLength = 10;

            if (parameter is string parameterString &&
                int.TryParse(parameterString, out int parsedLength))
            {
                maxLength = parsedLength;
            }

            if (text.Length <= maxLength)
                return text;

            return text[..maxLength] + "...";
        }

        public object ConvertBack(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
