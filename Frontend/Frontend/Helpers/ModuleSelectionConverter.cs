using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using static Frontend.Models.ModuleSelectionItem;

namespace Frontend.Helpers
{

    public class ModuleSelectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            if (((ModuleType)value).Equals(ModuleType.LECTURE))
            {
                var img = Application.Current.Resources["lecture_b"];
                return img;
            } else if (((ModuleType)value).Equals(ModuleType.TUTORIAL))
            {
                var img = Application.Current.Resources["tutorial_b"];
                return img;
            }
            else if (((ModuleType)value).Equals(ModuleType.PRACTICE))
            {
                var img = Application.Current.Resources["practicum_b"];
                return img;
            }
            else
            {
                var img = Application.Current.Resources["exercise_b"];
                return img;
            }     
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

