using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Frontend.Helpers
{
    public class TimeToYCoordinatesConverter : IMultiValueConverter
    {
        #region IValueConverter Members

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double totalHeight = System.Convert.ToDouble(value[1]);
            TimeSpan ModuleStartTime = new TimeSpan(
                System.Convert.ToInt32((value[0] as string).Split(':')[0]),
                System.Convert.ToInt32((value[0] as string).Split(':')[1]),
                0);

            double heightPerRow = totalHeight / (Globals.GetDuration() / Globals.Subdivisions) + Globals.RowPadding;
            TimeSpan timeFromStart = ModuleStartTime - Globals.StartTime;
            return (timeFromStart.TotalMinutes/Globals.Subdivisions) * heightPerRow;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class TimeToXCoordinatesConverter : IMultiValueConverter
    {
        #region IValueConverter Members

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double totalWidth = System.Convert.ToDouble(value[0]);
            //double timeWidth = System.Convert.ToDouble(parameters[1]);
            double timeWidth = System.Convert.ToDouble(value[1]);
            int weekday = System.Convert.ToInt32(value[2]);
            double widthPerItem = (totalWidth - timeWidth) / Globals.weekdays;
            

            return timeWidth + (weekday) * widthPerItem;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ItemWidthConverter : IMultiValueConverter
    {
        #region IValueConverter Members

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double totalWidth = System.Convert.ToDouble(value[0]);
            double timeWidth = System.Convert.ToDouble(value[1]);
            double width = ((totalWidth - timeWidth) / Globals.weekdays) - Globals.Space;
            return width < 0 ? 0 : width;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ItemHeightConverter : IMultiValueConverter
    {
        #region IValueConverter Members

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double totalHeight = System.Convert.ToDouble(value[2]);
            TimeSpan ModuleStartTime = new TimeSpan(
                System.Convert.ToInt32((value[0] as string).Split(':')[0]),
                System.Convert.ToInt32((value[0] as string).Split(':')[1]),
                0);
            TimeSpan ModuleEndTime = new TimeSpan(
                System.Convert.ToInt32((value[1] as string).Split(':')[0]),
                System.Convert.ToInt32((value[1] as string).Split(':')[1]),
                0);
            TimeSpan duration = ModuleEndTime - ModuleStartTime;
            double heightPerRow = totalHeight / (Globals.GetDuration() / Globals.Subdivisions) + Globals.RowPadding;
            return (duration.TotalMinutes / Globals.Subdivisions) * heightPerRow;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}