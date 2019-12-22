using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class Login_PasswordInput : UserControl
    {
        public Login_PasswordInput()
        {
            InitializeComponent();
        }

        private void PasswordInput_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordInput.Text = "";
            PasswordInput.GotFocus -= PasswordInput_GotFocus;
        }

        private void PasswordInput_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (PasswordInput.Text != "")
            {
                PasswordInput.SelectAll();
            }
        }
    }
}
