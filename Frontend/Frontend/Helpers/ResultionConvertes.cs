using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Frontend.Helpers
{
    class PixelCalculator
    {
        

        public static double PointsToPixels(double points)
        {
            return points * (CalculateDpiX()/ 72);
        }

        public static double PixelsToPoints(double pixels)
        {
            return pixels * (72 /CalculateDpiX());
        }

        private static double CalculateDpiX()
        {
            var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
            return (int)dpiXProperty.GetValue(null, null);

        }

    }
   
}
