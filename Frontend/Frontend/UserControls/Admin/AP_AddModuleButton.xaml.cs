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
    /// Interaction logic for AP_AddModuleButton.xaml
    /// </summary>
    public partial class AP_AddModuleButton : UserControl
    {
        public AP_AddModuleButton()
        {
            InitializeComponent();
        }

        public ICommand AP_AddModuleButtonCommand
        {
            get { return (ICommand)GetValue(AP_AddModuleButtonCommandProperty); }
            set { SetValue(AP_AddModuleButtonCommandProperty, value); }
        }

        public static readonly DependencyProperty AP_AddModuleButtonCommandProperty =
            DependencyProperty.Register("AP_AddModuleButtonCommand", typeof(ICommand), typeof(AP_AddModuleButton), new UIPropertyMetadata(null));

        private void OpenDialog(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("open dialog");
            CreateModule_Dialog d = new CreateModule_Dialog();
            d.Show();
            d.Topmost = true;
            FillDialog(d);

        }

        private void FillDialog(CreateModule_Dialog d)
        {
           // gefuellte Felder in Dialog
        }
    }
}
