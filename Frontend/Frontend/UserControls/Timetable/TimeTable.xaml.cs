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

        private object _LastEditModuleOpener = null;

        public TimeTable()
        {
            InitializeComponent();
            Focusable = true;
            Loaded += (s, e) => Keyboard.Focus(this);
        }

        private void TimetableItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!moduleEdit.IsOpen)
            {
                Console.WriteLine("MouseEnter TimeTableItem");
                popUp.Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse;
                uc.MouseLeave += TimetableItem_MouseLeave;
                popUp.IsOpen = true;
                uc.item.Module = ((TimetableItem)sender).Module;
            }

        }

        private void TimetableItem_MouseLeave(object sender, MouseEventArgs e)
        {
            popUp.IsOpen = false;
        }

        private void TimetableItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Console.WriteLine("MouseLeftClick TimeTableItem");
            if (UserInformation.Instance.IsAdmin)
            {
                if (moduleEdit.IsOpen)
                {
                    moduleEdit.IsOpen = false;
                }
                else
                {
                    var tti = (TimetableItem)sender;
                    moduleEdit.PlacementTarget = tti;
                    moduleEdit.Child = ModuleEditor;
                    ModuleEditor.viewmodel.EditTimetableModule = tti.Module.Module;
                    moduleEdit.IsOpen = true;
                    popUp.IsOpen = false;
                    _LastEditModuleOpener = sender;
                }
            }
        }
    }
}
