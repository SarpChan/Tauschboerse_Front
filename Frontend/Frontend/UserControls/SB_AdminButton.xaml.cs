using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class SB_AdminButton : UserControl
    {
        public SB_AdminButton() { InitializeComponent(); }
        /* Dependency Properties für eigene *bindbare* Properties */
        public ICommand SB_AdminButtonCommand
        {
            get { return (ICommand)GetValue(SB_AdminButtonCommandProperty); }
            set { SetValue(SB_AdminButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_AdminButtonCommandProperty =
            DependencyProperty.Register("SB_AdminButtonCommand", typeof(ICommand), typeof(SB_AdminButton), new UIPropertyMetadata(null));
    }
}
