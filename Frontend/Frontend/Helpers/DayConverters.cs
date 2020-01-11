using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Frontend.Helpers
{
    public class DayWidthConverter : IMultiValueConverter
    {
        /// <summary>
        /// Berechnet die Breite eines Tages
        /// </summary>
        /// <param name="value">Array mit benötigten Werten zum Umrechnen
        /// Hier: Komplette Breite, Breite der Zeitspalte</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Breite in Pixel</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double totalWidth = System.Convert.ToDouble(values[0]);
            double timeWidth = System.Convert.ToDouble(values[1]);
            return (totalWidth - timeWidth) / Globals.weekdays;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DayPositionConverter : IMultiValueConverter
    {
        /// <summary>
        /// Berechnet die X Position eines Tageslabels
        /// </summary>
        /// <param name="value">Array mit benötigten Werten zum Umrechnen
        /// Hier: Komplette Breite, Breite der Zeitspalte, Index des Tages</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Abstand von Links in Pixel </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double totalWidth = System.Convert.ToDouble(values[0]);
            double timeWidth = System.Convert.ToDouble(values[1]);
            double index = System.Convert.ToInt32(values[2]);
            return ((totalWidth - timeWidth) / Globals.weekdays) * index + timeWidth;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }



}
