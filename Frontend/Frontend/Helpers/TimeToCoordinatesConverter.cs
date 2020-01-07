using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
            //Console.WriteLine(value[2]);
            int weekday = System.Convert.ToInt32(value[2]);
            int rowPos = TimeConverterHelper.CalculateModuleRowPosition((TimetableModule)value[3], (IList<TimetableModule>)value[4]);
            int divder = TimeConverterHelper.CalculateModuleWidthDivider((TimetableModule)value[3], (IList<TimetableModule>)value[4]);
            double widthPerItem = (totalWidth - timeWidth) / Globals.weekdays;

            return (timeWidth + (weekday) * widthPerItem) + ((widthPerItem/divder)*(rowPos-1));
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
        /// Hier: Komplette Breite, Breite der Zeitspalte,act. Groups, List aller Groups</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
        /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
        /// <returns>Pixelbreite</returns>
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {

            int divider = TimeConverterHelper.CalculateModuleWidthDivider((TimetableModule)value[2],(IList<TimetableModule>)value[3]);

            double totalWidth = System.Convert.ToDouble(value[0]);
            double timeWidth = System.Convert.ToDouble(value[1]);
            double width = ((totalWidth - timeWidth) / Globals.weekdays) -  PixelCalculator.PointsToPixels(Globals.Space);
            width /= divider;

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

    class TimeConverterHelper
    {

        private static int CalculateModuleWidthDivider(int counter, int index, int startTime, int endTime, String day, TimetableModule module, TimetableModule[] items)
        {

            for (int i = index; i < items.Length; i++)
            {
                if (items[i].Day.Equals(day) && !items[i].Equals(module))
                {

                    var s2 = TimeStringToInt(items[i].StartTime as String);
                    var e2 = TimeStringToInt(items[i].EndTime as String);

                    if ((startTime <= s2 && endTime > s2) || (startTime < e2 && endTime >= e2))
                    {

                        int founded = CalculateModuleWidthDivider(1 + counter, 1 + i, Math.Min(startTime,s2),Math.Min(endTime,e2), day, module, items);

                        int behinde = 0;
                        if (e2 < endTime)
                        {
                            behinde = CalculateModuleWidthDivider(counter, 1 + i, e2, endTime, day, module, items);
                        }

                        int before = 0;
                        if (startTime < s2)
                        {
                            before = CalculateModuleWidthDivider(counter, 1 + i, startTime, s2, day, module, items);
                        }

                        return Math.Max(Math.Max(founded, behinde), before);

                    }
                }
            }

            return counter;
        }


        /// <summary>
        /// Brechnet wie viele Module neben dem untersuchten Modul liegen
        /// </summary>
        /// <param name="module">das untersuchte Module</param>
        /// <param name="moduleList">Liste aller Module</param>
        /// <returns>Anzahl der Module neben dem u. Module ink. u. Module</returns>
        public static int CalculateModuleWidthDivider(TimetableModule module, IList<TimetableModule> moduleList)
        {

            int divider = 1;

            var startTime = TimeStringToInt(module.StartTime as String);
            var endTime = TimeStringToInt(module.EndTime as String);


            divider =  CalculateModuleWidthDivider(divider, 0, startTime, endTime, module.Day,module, moduleList.ToArray());

            //Console.WriteLine("Module: " + module.CourseName + "Div :" + divider);
            return divider;
        }

        private static int CalculateModuleRowPosition(int counter, int index, int startTime, int endTime,long id,String day, TimetableModule module, TimetableModule[] items)
        {

            for(int i =index; i<items.Length;i++)
            {
                if (items[i].Day.Equals(day) && !items[i].Equals(module))
                {

                    var s2 = TimeStringToInt(items[i].StartTime as String);
                    var e2 = TimeStringToInt(items[i].EndTime as String);

                    if ((startTime <= s2 && endTime > s2) || (startTime < e2 && endTime >= e2))
                    {
                        if (id > System.Convert.ToInt64(items[i].ID))
                        {

                            var found = CalculateModuleRowPosition(1+counter, 1+i, Math.Min(startTime, s2), Math.Min(endTime, e2), id, day,module, items);
                            int behinde = 0;
                            if (e2 < endTime)
                            {
                                behinde = CalculateModuleRowPosition(counter, 1 + i, e2, endTime, id, day,module, items);
                            }

                            int before = 0;
                            if (startTime < s2)
                            {
                                before = CalculateModuleRowPosition(counter, 1+i, startTime, s2, id, day,module, items);
                            }

                            //Console.WriteLine("founde:", found, "behinde: ", behinde, "before", before);

                            return Math.Max(Math.Max(found, behinde),before);
                           
                        }
                    }
                }
            }
            return counter;
        }

        /// <summary>
        /// Berechnet (auf grund der Id) an welcher Postion einer Splate das Module liegen muss 
        /// </summary>
        /// <param name="module">das untersuchte Module</param>
        /// <param name="moduleList">Liste aller Module</param>
        /// <returns>SplatenPostion des Modules</returns>
        public static int CalculateModuleRowPosition(TimetableModule module, IList<TimetableModule> moduleList)
        {
            int pos = 1;

            var startTime = TimeStringToInt(module.StartTime as String);
            var endTime = TimeStringToInt(module.EndTime as String);
           
            pos = CalculateModuleRowPosition(pos, 0, startTime, endTime, System.Convert.ToInt64(module.ID), module.Day,module, moduleList.ToArray());

            //Console.WriteLine("Module: "+module.CourseName+"Pos :" + pos);
            return pos;
        }

        private static int TimeStringToInt(String time)
        {
            return System.Convert.ToInt32(time.Split(':')[0]) * 60 + System.Convert.ToInt32(time.Split(':')[1]);
        }
    }
}