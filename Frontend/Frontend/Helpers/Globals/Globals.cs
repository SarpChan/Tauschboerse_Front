using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    //TODO Helpers.Globals: Change to Properties
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
        public static int RowSeperatorAmount = Convert.ToInt32(ConfigurationManager.AppSettings.Get("timetable.row.seperator.amount"));
        public static TimeSpan TimeSubdivision = new TimeSpan(0, 15, 0);
        public static string[] RowColors = { 
            ConfigurationManager.AppSettings.Get("timetable.color.row1"),
            ConfigurationManager.AppSettings.Get("timetable.color.row2")
        };
        public static string RowSeperatorColor = ConfigurationManager.AppSettings.Get("timetable.color.rowseperator");
        public static double GetDuration()
        {
            return (EndTime - StartTime).TotalMinutes;
        }
        public static double Space = 1;
        public static double TimeTextFontSize = 12;
        public static double RowPadding = 0;

    }
}
