using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Frontend.Helpers
{
    class PageToUriConverter : MarkupExtension, IValueConverter
    {
        public PageToUriConverter(){}

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string uri = ((Page)value).GetType().Name + ".xaml";
            return uri;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
