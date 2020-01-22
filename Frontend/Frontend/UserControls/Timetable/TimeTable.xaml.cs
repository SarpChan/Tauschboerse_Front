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
using Frontend.Helpers;
using Frontend.View;

namespace Frontend.UserControls
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
        
        public TimeTable()
        {
            InitializeComponent();
            
        }

        private void TimetableItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("MouseEnter TimeTableItem");
            popUp.Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse;
            uc.MouseLeave += TimetableItem_MouseLeave;
            popUp.IsOpen = true;
            uc.item.Module = ((TimetableItem)sender).Module;


        }

        private void TimetableItem_MouseLeave(object sender, MouseEventArgs e)
        {
            popUp.IsOpen = false;
        }
    }
}
