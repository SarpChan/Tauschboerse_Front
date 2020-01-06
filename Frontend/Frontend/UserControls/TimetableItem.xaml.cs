using Frontend.Models;
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
    /// Interaction logic for TimetableItem.xaml
    /// </summary>
    public partial class TimetableItem : UserControl
    {
        public TimetableItem()
        {
            InitializeComponent();
            
        }

        #region properties

        public TimetableModule Module
        {
            get
            {
                return (TimetableModule)GetValue(ModuleProperty);
            }
            set
            {
                SetValue(ModuleProperty, value);
            }
        }
        public static readonly DependencyProperty ModuleProperty = DependencyProperty.Register("Module", typeof(TimetableModule), typeof(TimetableItem), new UIPropertyMetadata(null));

        
       
        
        #endregion
    }
}
