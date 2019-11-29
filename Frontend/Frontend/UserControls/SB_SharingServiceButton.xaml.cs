using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class SB_SharingServiceButton : UserControl
    {
        public SB_SharingServiceButton() { InitializeComponent(); }
        /* Dependency Properties für eigene *bindbare* Properties */
        public ICommand SB_SharingServiceButtonCommand
        {
            get { return (ICommand)GetValue(SB_SharingServiceButtonCommandProperty); }
            set { SetValue(SB_SharingServiceButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_SharingServiceButtonCommandProperty =
            DependencyProperty.Register("SB_SharingServiceButtonCommand", typeof(ICommand), typeof(SB_SharingServiceButton), new UIPropertyMetadata(null));
    }
}
