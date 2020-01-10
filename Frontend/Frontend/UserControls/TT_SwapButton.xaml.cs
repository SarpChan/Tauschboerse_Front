using Frontend.View;
using Microsoft.Win32;
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
    /// Interaction logic for TT_SwapButton.xaml
    /// </summary>
    public partial class TT_SwapButton : UserControl
    {
        public TT_SwapButton()
        {
            InitializeComponent();
        }
        public ICommand TT_SwapButtonCommand
        {
            get { return (ICommand)GetValue(TT_SwapButtonCommandProperty); }
            set { SetValue(TT_SwapButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TT_SwapButtonCommandProperty =
            DependencyProperty.Register("TT_SwapButtonCommand", typeof(ICommand), typeof(TT_SwapButton), new UIPropertyMetadata(null));


        private void openDialog(object sender, RoutedEventArgs e)
        {
            SO_Dialog swapDialog = new SO_Dialog();
            swapDialog.Show();
        }

        private void SwapButton_MouseLeave(object sender, MouseEventArgs m)
        {
            
        }
    }

}
