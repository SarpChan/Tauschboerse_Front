using System.Windows;

namespace Frontend.Helpers
{
    class BoolToVisibilityConverter : BoolToValueConverter<Visibility>
    {
    public BoolToVisibilityConverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
        }
    }
}
