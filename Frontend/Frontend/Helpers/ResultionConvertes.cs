using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Helpers
{
    class PixelCalculator
    {
        public static double PointsToPixels(double points)
        {
            return points * (96.0 / 72.0);
        }

        public static double PixelsToPoints(double pixels)
        {
            return pixels / (96.0 / 72.0);
        }
    }
   
}
