using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Frontend.Helpers
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            Console.WriteLine("ConvertBack"+str);
            return new DateTime(System.Convert.ToInt32(str.Split(':')[0]) * 60 + System.Convert.ToInt32(str.Split(':')[1]));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if(value == null)
            {
                return null;
            }

            var time = (DateTime)value;
            Console.WriteLine(time.ToString("HH:mm"));
            return time.ToString("HH:mm");
            
        }
    }
}
