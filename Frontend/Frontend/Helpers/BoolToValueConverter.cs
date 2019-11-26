using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Frontend.Helpers
{
    /// <summary>
    /// Use as the base class for BoolToXXX style converters
    /// </summary>
    /// <typeparam name="T"></typeparam>    
    public abstract class BoolToValueConverter<T> : MarkupExtension, IValueConverter
    {
        protected BoolToValueConverter()
        {
            this.TrueValue = default;
            this.FalseValue = default;
        }

        public T FalseValue { get; set; }
        public T TrueValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? this.TrueValue : this.FalseValue;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(this.TrueValue);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
