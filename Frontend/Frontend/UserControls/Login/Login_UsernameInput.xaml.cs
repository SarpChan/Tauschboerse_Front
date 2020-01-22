using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class Login_UsernameInput : UserControl
    {
        public Login_UsernameInput()
        {
            InitializeComponent();
        }

        private void UsernameInput_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernameInput.Text = "";
            UsernameInput.GotFocus -= UsernameInput_GotFocus;
        }

        private void UsernameInput_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (UsernameInput.Text != "")
            {
                UsernameInput.SelectAll();
            }
        }
    }
}
