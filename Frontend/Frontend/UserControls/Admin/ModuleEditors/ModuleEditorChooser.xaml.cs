using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for ModuleTimeEditor.xaml
    /// </summary>
    public partial class ModuleEditorChooser : UserControl
    {
        public ModuleEditorChooser()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(Parent is Popup)
            {
                ((Popup)Parent).IsOpen = false;
            } 
        }

        private void TypeButton_Click(object sender, RoutedEventArgs e)
        {
            var editor = new ModuleTypEditor();
            editor.viewmodel.EditTimetableModule = viewmodel.EditTimetableModule;
            if (Parent is Popup)
            {
                ((Popup)Parent).Child = editor;
            }
        }

        private void TimeButton_Click(object sender, RoutedEventArgs e)
        {

            var editor = new ModuleTimeEditor();
            editor.viewmodel.EditTimetableModule = viewmodel.EditTimetableModule;
            if (Parent is Popup)
            {

                ((Popup)Parent).Child = editor;
            }
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var editor = new ModuleDetailsEditor();
            editor.viewmodel.EditTimetableModule = viewmodel.EditTimetableModule;
            if (Parent is Popup)
            {
                ((Popup)Parent).Child = editor;
            }
        }

        private void MainInformationButton_Click(object sender, RoutedEventArgs e)
        {

            var editor = new ModuleMainInformationEditor();
            editor.viewmodel.EditTimetableModule = viewmodel.EditTimetableModule;
            if (Parent is Popup)
            {
                ((Popup)Parent).Child = editor;
            }
        }
    }

}
