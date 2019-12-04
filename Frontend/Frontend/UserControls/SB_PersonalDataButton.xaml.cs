using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class SB_PersonalDataButton : UserControl
    {
        public SB_PersonalDataButton() { InitializeComponent(); }
        /* Dependency Properties für eigene *bindbare* Properties */
        public ICommand SB_PersonalDataButtonCommand
        {
            get { return (ICommand)GetValue(SB_PersonalDataButtonCommandProperty); }
            set { SetValue(SB_PersonalDataButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_PersonalDataButtonCommandProperty =
            DependencyProperty.Register("SB_PersonalDataButtonCommand", typeof(ICommand), typeof(SB_PersonalDataButton), new UIPropertyMetadata(null));
    }
}
