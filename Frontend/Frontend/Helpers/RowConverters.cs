using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Frontend.Helpers
{
    /// <summary>
    /// Calculates the height each row has.
    /// </summary>
    public class RowHeightConverter : IMultiValueConverter
    {
        /// <summary>
        /// Berechnet die Höhe einer Spalte
        /// </summary>
        /// <param name="value">Array mit benötigten Werten zum Umrechnen
        /// Hier: Komplette Höhe, Höhe des Headers mit den Wochentagen</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Höhe einer Spalte in Pixel</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double totalHeight = System.Convert.ToDouble(values[0]);
            double headerHeight = System.Convert.ToDouble(values[1]);
            int rowAmount = (int)Globals.GetDuration() / Globals.Subdivisions;
            return (totalHeight-headerHeight)/rowAmount + Globals.RowPadding;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Berechnet die Y Position einer Spalte
    /// </summary>
    /// <param name="value">Array mit benötigten Werten zum Umrechnen
    /// Hier: Komplette Höhe, Spaltenindex</param>
    /// <param name="targetType">n/a</param>
    /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
    /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
    /// <returns>Y Pos einer Spalte in Pixel</returns>
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

    /// <summary>
    /// Warum auch immer ist headerHeight nicht von nöten
    /// </summary>
    public class SeperatorHeightConverters : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double totalHeight = System.Convert.ToDouble(values[0]);
            double headerHeight = System.Convert.ToDouble(values[1]);
            Console.WriteLine("Header Height " + headerHeight);
            return (totalHeight);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SeperatorPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double totalWidth = System.Convert.ToDouble(values[0]);
            double timeWidth = System.Convert.ToDouble(values[1]);
            int columnIndex = System.Convert.ToInt32(values[2]);
            double widthPerColumn = (totalWidth - timeWidth) / Globals.weekdays;
            return timeWidth + widthPerColumn * (columnIndex) - Globals.Space;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RowLineColorConverter : IMultiValueConverter
    {
        /// <summary>
        /// Berechnet die Farbe eines Seperators
        /// </summary>
        /// <param name="value">Array mit benötigten Werten zum Umrechnen
        /// Hier: Spaltenindex</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Hintergrundfarbe als SolidColorBrush.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int columnIndex = System.Convert.ToInt32(values[0]);
            SolidColorBrush brush = null;
            if (columnIndex % Globals.RowSeperatorAmount == 0 && columnIndex != 0)
            {
                brush = (SolidColorBrush)(new BrushConverter().ConvertFrom(Globals.RowSeperatorColor));
            } else
            {
                brush = null;
            }
           
            return brush;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
