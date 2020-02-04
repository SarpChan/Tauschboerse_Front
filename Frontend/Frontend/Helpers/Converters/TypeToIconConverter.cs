using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Frontend.Helpers
{
    class TypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            TimetableModule.ModuleType type;

            if (value != null)
            {
                type = (TimetableModule.ModuleType)value;
            }
            else
            {
                type = TimetableModule.ModuleType.LECTURE;
            }

            switch (type)
            {
                case TimetableModule.ModuleType.PRACTICE: return LoadIcon("timetabel.item.icon.practicaltraining");
                case TimetableModule.ModuleType.TUTORIAL: return LoadIcon("timetabel.item.icon.tutorial");
                case TimetableModule.ModuleType.TEST: return LoadIcon("timetabel.item.icon.exercise");
                default: return LoadIcon("timetabel.item.icon.lecture");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private ImageBrush LoadIcon(string configName)
        {
            {

                var uriScource = new Uri(ConfigurationManager.AppSettings.Get(configName));
                var imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(uriScource);
                return imageBrush;
            }
        }
    }
}
