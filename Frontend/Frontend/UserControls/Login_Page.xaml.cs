using Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend.UserControls
{
    /// <summary>
    /// Interaction logic for Login_Page.xaml
    /// </summary>
    public partial class Login_Page : UserControl
    {
       

        public Login_Page()
        {
            InitializeComponent();
        }

        private void PasswordInput_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordInput.Text = "";
            PasswordInput.GotFocus -= PasswordInput_GotFocus;
        }

        private void UsernameInput_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernameInput.Text = "";
            UsernameInput.GotFocus -= UsernameInput_GotFocus;
        }

        private void PasswordInput_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (PasswordInput.Text != "")
            {
                PasswordInput.SelectAll();
            }
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
