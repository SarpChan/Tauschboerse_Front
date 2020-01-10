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
using System.Windows.Shapes;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for SO_Dialog.xaml
    /// </summary>
    public partial class SO_Dialog : Window
    {
        public SO_Dialog()
        {
            InitializeComponent();
        }

        public ICommand D_CancelButtonCommand
        {
            get { return (ICommand)GetValue(D_CancelButtonCommandProperty); }
            set { SetValue(D_CancelButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty D_CancelButtonCommandProperty =
            DependencyProperty.Register("D_CancelButtonCommand", typeof(ICommand), typeof(SO_Dialog), new UIPropertyMetadata(null));


        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

     
    }
}
