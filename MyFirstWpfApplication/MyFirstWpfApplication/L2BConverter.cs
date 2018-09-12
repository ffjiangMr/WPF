using System;
using System.Globalization;
using System.Windows.Data;

namespace MyFirstWpfApplication
{
    public class L2BConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Int32 textLength = (Int32)value;
            return textLength > 6 ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
