using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class TB_LogoutButton : UserControl
    {
        public TB_LogoutButton() { InitializeComponent(); }
        public ICommand TB_LogoutButtonCommand
        {
            get { return (ICommand)GetValue(TB_LogoutButtonCommandProperty); }
            set { SetValue(TB_LogoutButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TB_LogoutButtonCommandProperty =
            DependencyProperty.Register("TB_LogoutButtonCommand", typeof(ICommand), typeof(TB_LogoutButton), new UIPropertyMetadata(null));
    }
}
