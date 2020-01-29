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
    public partial class ModuleDetailsEditor : UserControl
    {
        public ModuleDetailsEditor()
        {
            InitializeComponent();
            GroupComboBox.SelectionChanged += (sender, e) => GroupComboBox_Changed(sender);
            GroupComboBox.DropDownClosed += (sender, e) => GroupComboBox_Changed(sender);

            RoomComboBox.SelectionChanged += (sender,e) =>RoomComboBox_Changed(sender);
            RoomComboBox.DropDownClosed += (sender, e) => RoomComboBox_Changed(sender);

            LectureComboBox.SelectionChanged += (sender, e)=>LectureComboBox_Changed(sender);
            LectureComboBox.DropDownClosed += (sender, e) => LectureComboBox_Changed(sender);
        }

        #region ComboBoxChanged

        private void LectureComboBox_Changed(object sender)
        {
            var combobox = (ComboBox)sender;
            viewmodel.EditTimetableModule.PersonName = combobox.Text;
        }

        private void RoomComboBox_Changed(object sender)
        {
            var combobox = (ComboBox)sender;
            viewmodel.EditTimetableModule.RoomNumber = combobox.Text;
        }

        private void GroupComboBox_Changed(object sender)
        {
            var combobox = (ComboBox)sender;
            viewmodel.EditTimetableModule.GroupChar = combobox.Text;
            
        }

        #endregion

        public String DeaktiveteSaveButton
        {
            set
            {
                if (value.Equals("true"))
                {
                    saveButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    saveButton.Visibility = Visibility.Visible;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(Parent is Popup)
            {
                var chooser = new ModuleEditorChooser();
                chooser.viewmodel.EditTimetableModule = viewmodel.EditTimetableModule;

                ((Popup)Parent).Child = chooser;
            }
        }
    }

}
