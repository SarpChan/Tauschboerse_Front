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

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for TimeTable.xaml
    /// </summary>
    /// 

    /*
     * <project:TimetableViewModel x:Key="TimetableViewMode"/>
     * 
     * 
     */
    public partial class TimeTable : UserControl
    {

        private int Days = 6;
        public TimeTable()
        {
            InitializeComponent();
            
        }

        public readonly DependencyProperty ColumnWidthProperty = DependencyProperty.Register("ColumWidth", typeof(double), typeof(TimeTable), new UIPropertyMetadata(null));

        public double ColumnWidth
        {
            get
            {
                return (this.ActualWidth - text_zeit.ActualWidth) / Days;
            }
        }



    }
}
