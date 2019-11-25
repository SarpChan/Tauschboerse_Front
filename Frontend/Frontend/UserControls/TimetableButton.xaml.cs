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
    public partial class TimetableButton : UserControl
    {
        public TimetableButton() { InitializeComponent(); }
        /* Dependency Properties für eigene *bindbare* Properties */
        public ICommand HomeButtonCommand
        {
            get { return (ICommand)GetValue(HomeButtonCommandProperty); }
            set { SetValue(HomeButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty HomeButtonCommandProperty =
            DependencyProperty.Register("HomeButtonCommand", typeof(ICommand), typeof(TimetableButton), new UIPropertyMetadata(null));
    }
}
