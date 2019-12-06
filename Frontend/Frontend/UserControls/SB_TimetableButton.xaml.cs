using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class SB_TimetableButton : UserControl
    {
        public SB_TimetableButton() { InitializeComponent(); }
        /* Dependency Properties für eigene *bindbare* Properties */
        public ICommand SB_TimetableButtonCommand
        {
            get { return (ICommand)GetValue(SB_TimetableButtonCommandProperty); }
            set { SetValue(SB_TimetableButtonCommandProperty, value); }
        }
        
        public static readonly DependencyProperty SB_TimetableButtonCommandProperty =
            DependencyProperty.Register("SB_TimetableButtonCommand", typeof(ICommand), typeof(SB_TimetableButton), new UIPropertyMetadata(null));
    }
}
