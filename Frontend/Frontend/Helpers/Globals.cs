using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    //TODO: Change to Properties
    /// <summary>
    /// Temporary solution for saving global variables that can be changed
    /// </summary>
    static class Globals
    {
        public static string[] Weekdays = new string[]
        {
            "Montag","Dienstag","Mittwoch","Donnerstag","Freitag","Samstag","Sonntag"
        };

        public static string[] WeekdaysAbbreviation = new string[]
        {
            "MO","DI","MI","DO","FR","SA","SO"
        };

        public static int weekdays = 6;
        public static TimeSpan StartTime = new TimeSpan(8,15,0);
        public static TimeSpan EndTime = new TimeSpan(19, 15, 0);
        public static int Subdivisions = 15;
        public static int RowSeperatorAmount = 4;
        public static TimeSpan TimeSubdivision = new TimeSpan(0, 15, 0);
        public static string[] RowColors = { "#FFD2E7EB", "#FFFFFFFF" };
        public static string RowSeperatorColor = "#FF7D7E7E";
        public static double GetDuration()
        {
            return (EndTime - StartTime).TotalMinutes;
        }
        public static double Space = 2;
        public static double TimeTextFontSize = 12;
        public static double RowPadding = 0;

    }
}
