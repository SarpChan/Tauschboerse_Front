using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class Login_LoginButton : UserControl
    {
        public Login_LoginButton() { InitializeComponent(); }
        public ICommand LoginButtonCommand
        {
            get { return (ICommand)GetValue(LoginButtonCommandProperty); }
            set { SetValue(LoginButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty LoginButtonCommandProperty =
            DependencyProperty.Register("LoginButtonCommand", typeof(ICommand), typeof(Login_LoginButton), new UIPropertyMetadata(null));
    }
}
