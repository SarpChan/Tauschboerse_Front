using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Frontend.Helpers
{
    public class RowHeightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double totalHeight = System.Convert.ToDouble(values[0]);
            double headerHeight = System.Convert.ToDouble(values[1]);
            int rowAmount = (int)Globals.GetDuration() / Globals.Subdivisions;
            return (totalHeight-headerHeight)/rowAmount+10;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RowPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double totalHeight = System.Convert.ToDouble(values[0]);
            int rowAmount = (int)Globals.GetDuration() / Globals.Subdivisions;
            int rowIndex = System.Convert.ToInt32(values[1]);
            double rowHeight = (double)totalHeight / rowAmount;

            return rowIndex*rowHeight;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
