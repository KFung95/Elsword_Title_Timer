using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace PhotonTracker
{
    public class BoolToVisibilityConverter: MarkupExtension, IValueConverter
    {
        private static BoolToVisibilityConverter instance = new BoolToVisibilityConverter();

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return instance ?? new BoolToVisibilityConverter();
        }

        public object Convert(object obj, Type type, object param, CultureInfo culture)
        {
            return obj != null && ((bool)obj) == true ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
