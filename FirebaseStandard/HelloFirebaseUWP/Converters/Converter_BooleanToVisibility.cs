using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace HelloFirebaseUWP.Converters
{
    public class Converter_BooleanToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
