using System;
using System.Data.SqlTypes;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace DemoLight.WpfView.Helpers
{
    public class BoolToYesNoSymbolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bValue = false;
            if (value is bool b) bValue = b;
            else if (value is bool?) bValue = (bool?)value ?? false;
            return bValue ? "" : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}