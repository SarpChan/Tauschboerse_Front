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

        /// <summary>
        /// Konvertiert (momentan) einen Zeitstring in ein Y Koordinate
        /// </summary>
        /// Splittet momenatan die Zeit an einem ":" um Stunde und Minute zu erhalten
        /// <param name="value">Array mit benötigten Werten zum Umrechnen
        /// Hier: Zeit, Komplette Höhe </param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Pixel für die Y-Koordniate</returns>
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            double totalHeight = System.Convert.ToDouble(value[1]);
            TimeSpan ModuleStartTime = new TimeSpan(
                System.Convert.ToInt32((value[0] as string).Split(':')[0]),
                System.Convert.ToInt32((value[0] as string).Split(':')[1]),
                0);

            double heightPerRow = totalHeight / (Globals.GetDuration() / Globals.Subdivisions) + Globals.RowPadding;
            TimeSpan timeFromStart = ModuleStartTime - Globals.StartTime;
            return (timeFromStart.TotalMinutes / Globals.Subdivisions) * heightPerRow;
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
        /// <summary>
        /// Konvertiert Wochentag in ein X Koordinate
        /// </summary>
        /// Splittet momenatan die Zeit an einem ":" um Stunde und Minute zu erhalten
        /// <param name="value">Array mit benötigten Werten zum Umrechnen
        /// Hier: Komplette Breite, Breite der Zeitspalte, Tag</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Pixel für die X-Koordniate</returns>
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {

            double totalWidth = System.Convert.ToDouble(value[0]);
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
        /// <summary>
        /// Berechnet die Breite pro Spalte
        /// </summary>
        /// <param name="value">Array mit benötigten Werten zum Umrechnen
        /// Hier: Komplette Breite, Breite der Zeitspalte</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Pixelbreite</returns>
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {

            int divider = ConverterHelper.getModuleWidthDivider((ModuleDummy)value[0],(IList<ModuleDummy>)value[1]);

            double totalWidth = System.Convert.ToDouble(value[2]);
            double timeWidth = System.Convert.ToDouble(value[3]);
            double width = ((totalWidth - timeWidth) / Globals.weekdays) - Globals.Space;
            width /= divider;

            return width < 0 ? 0 : width;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private int TimeStringToInt(String time)
        {
            return System.Convert.ToInt32(time.Split(':')[0]) * 60 + System.Convert.ToInt32(time.Split(':')[1]);
        }

        #endregion
    }

    public class ItemHeightConverter : IMultiValueConverter
    {
        #region IValueConverter Members
        /// <summary>
        /// Berechnet die Höhe eines TimetableItems
        /// </summary>
        /// <param name="value">Array mit benötigten Werten zum Umrechnen
        /// Hier: Startzeit, Endzeit, Komplette Höhe</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Höhe in Pixel</returns>
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

    class ConverterHelper
    {
        public static int getModuleWidthDivider(ModuleDummy module, IList<ModuleDummy> moduleList)
        {

            int divider = 0;

            var startTime = TimeStringToInt(module.StartTime as String);
            var endTime = TimeStringToInt(module.EndTime as String);

            foreach (ModuleDummy cmp in moduleList)
            {
                if (module.Day.Equals(cmp.Day))
                {
                    var s2 = TimeStringToInt(cmp.StartTime as String);
                    var e2 = TimeStringToInt(cmp.EndTime as String);

                    if ((startTime <= s2 && endTime >= s2) || (startTime <= e2 && endTime >= e2))
                    {
                        divider++;
                    }

                }
            }

            return divider;
        }

        private static int TimeStringToInt(String time)
        {
            return System.Convert.ToInt32(time.Split(':')[0]) * 60 + System.Convert.ToInt32(time.Split(':')[1]);
        }
    }
}