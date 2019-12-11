using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class SB_HomeButton : UserControl
    {
        public SB_HomeButton() { InitializeComponent(); }
        /* Dependency Properties für eigene *bindbare* Properties */
        public ICommand SB_HomeButtonCommand
        {
            get { return (ICommand)GetValue(SB_HomeButtonCommandProperty); }
            set { SetValue(SB_HomeButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_HomeButtonCommandProperty =
            DependencyProperty.Register("SB_HomeButtonCommand", typeof(ICommand), typeof(SB_HomeButton), new UIPropertyMetadata(null));
    }
}
