using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Helpers.Calculators
{
    class TimeCoodinatesCalculator
    {
        public static double ConvertTimeToYCoordinates(double totalHeight, TimeSpan moduleStartTime)
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
            {

                double heightPerRow = totalHeight / (Globals.GetDuration() / Globals.Subdivisions) + Globals.RowPadding;
                TimeSpan timeFromStart = moduleStartTime - Globals.StartTime;
                return (timeFromStart.TotalMinutes / Globals.Subdivisions) * heightPerRow;
            }

            #endregion
        }

        public static double ConvertTimeToXCoordinates(double totalWidth, double timeWidth, int weekday, TimetableViewModelModule ttvmm, IList<TimetableModule> moduleList)
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

            int rowPos = TimeConverterHelper.CalculateModuleRowPosition(ttvmm.Module, moduleList);
            int divder = TimeConverterHelper.CalculateModuleWidthDivider(ttvmm, moduleList);
            double widthPerItem = (totalWidth - timeWidth) / Globals.weekdays;

            return (timeWidth + (weekday) * widthPerItem) + ((widthPerItem / divder) * (rowPos - 1));
            #endregion
        }

        public static double ConvertDayToItemWidth(double totalWidth, double timeWidth, TimetableViewModelModule module, IList<TimetableModule> moduleList)
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
            int divider = TimeConverterHelper.CalculateModuleWidthDivider(module, moduleList);

            double width = ((totalWidth - timeWidth) / Globals.weekdays) - PixelCalculator.PointsToPixels(Globals.Space);
            width /= divider;

            return width < 0 ? 0 : width;
        }


        #endregion


        /// <summary>
            /// Berechnet die Höhe eines TimetableItems
            /// </summary>
            /// <param name="value">Array mit benötigten Werten zum Umrechnen
            /// Hier: Startzeit, Endzeit, Komplette Höhe</param>
            /// <param name="targetType">n/a</param>
            /// <param name="parameter">Parameter der bei gleichen Werten Ergebnis beeinflusst</param>
            /// <param name="culture">Aktuelle Sprache (wird nicht benutzt)</param>
            /// <returns>Höhe in Pixel</returns>
        public static double ItemHeightConverter(double totalHeight, TimeSpan moduleStartTime, TimeSpan moduleEndTime)
        {
            #region IValueConverter Members
            

            TimeSpan duration = moduleEndTime - moduleStartTime;
            double heightPerRow = totalHeight / (Globals.GetDuration() / Globals.Subdivisions) + Globals.RowPadding;
            return (duration.TotalMinutes / Globals.Subdivisions) * heightPerRow;
        }

        #endregion


        public static int TimeStringToInt(String time)
        {
            return System.Convert.ToInt32(time.Split(':')[0]) * 60 + System.Convert.ToInt32(time.Split(':')[1]);
        }
    }



    class TimeConverterHelper
    {

        private static int CalculateModuleWidthDivider(int counter, int index, int startTime, int endTime, String day, TimetableViewModelModule ttvmm, TimetableModule[] items)
        {

            for (int i = index; i < items.Length; i++)
            {
                if (items[i].Day.Equals(day) && !items[i].Equals(ttvmm.Module))
                {
                    
                    var s2 = TimeCoodinatesCalculator.TimeStringToInt(items[i].StartTime as String);
                    var e2 = TimeCoodinatesCalculator.TimeStringToInt(items[i].EndTime as String);

                    if ((startTime <= s2 && endTime > s2) || (startTime < e2 && endTime >= e2))
                    {

                        int founded = CalculateModuleWidthDivider(1 + counter, 1 + i, Math.Min(startTime, s2), Math.Min(endTime, e2), day, ttvmm, items);

                        int behinde = 0;
                        if (e2 < endTime)
                        {
                            behinde = CalculateModuleWidthDivider(counter, 1 + i, e2, endTime, day, ttvmm, items);
                        }

                        int before = 0;
                        if (startTime < s2)
                        {
                            before = CalculateModuleWidthDivider(counter, 1 + i, startTime, s2, day, ttvmm, items);
                        }

                        return Math.Max(Math.Max(founded, behinde), before);

                    }
                }
            }

            return counter;
        }


        /// <summary>s
        /// Brechnet wie viele Module neben dem untersuchten Modul liegen
        /// </summary>
        /// <param name="module">das untersuchte Module</param>
        /// <param name="moduleList">Liste aller Module</param>
        /// <returns>Anzahl der Module neben dem u. Module ink. u. Module</returns>
        public static int CalculateModuleWidthDivider(TimetableViewModelModule ttvmm, IList<TimetableModule> moduleList)
        {

            int divider = 1;

            var startTime = TimeCoodinatesCalculator.TimeStringToInt(ttvmm.Module.StartTime as String);
            var endTime = TimeCoodinatesCalculator.TimeStringToInt(ttvmm.Module.EndTime as String);


            divider = CalculateModuleWidthDivider(divider, 0, startTime, endTime, ttvmm.Module.Day, ttvmm, moduleList.ToArray());

            //Console.WriteLine("Module: " + ttvmm.Module.CourseName + "Div :" + divider);
            return divider;
        }

        private static int CalculateModuleRowPosition(int counter, int index, int startTime, int endTime, long id, String day, TimetableModule module, TimetableModule[] items)
        {

            for (int i = index; i < items.Length; i++)
            {
                if (items[i].Day.Equals(day) && !items[i].Equals(module))
                {

                    var s2 = TimeCoodinatesCalculator.TimeStringToInt(items[i].StartTime as String);
                    var e2 = TimeCoodinatesCalculator.TimeStringToInt(items[i].EndTime as String);

                    if ((startTime <= s2 && endTime > s2) || (startTime < e2 && endTime >= e2))
                    {
                        if (id > System.Convert.ToInt64(items[i].ID))
                        {

                            var found = CalculateModuleRowPosition(1 + counter, 1 + i, Math.Min(startTime, s2), Math.Min(endTime, e2), id, day, module, items);
                            int behinde = 0;
                            if (e2 < endTime)
                            {
                                behinde = CalculateModuleRowPosition(counter, 1 + i, e2, endTime, id, day, module, items);
                            }

                            int before = 0;
                            if (startTime < s2)
                            {
                                before = CalculateModuleRowPosition(counter, 1 + i, startTime, s2, id, day, module, items);
                            }

                            //Console.WriteLine("founde:", found, "behinde: ", behinde, "before", before);

                            return Math.Max(Math.Max(found, behinde), before);

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

            var startTime = TimeCoodinatesCalculator.TimeStringToInt(module.StartTime as String);
            var endTime = TimeCoodinatesCalculator.TimeStringToInt(module.EndTime as String);

            pos = CalculateModuleRowPosition(pos, 0, startTime, endTime, System.Convert.ToInt64(module.ID), module.Day, module, moduleList.ToArray());

            //Console.WriteLine("Module: "+module.CourseName+"Pos :" + pos);
            return pos;
        }


    }

}