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
    public partial class ModuleTimeEditor : UserControl
    {
        public ModuleTimeEditor()
        {
            InitializeComponent();

            startTimePicker.ValueChanged += StartTimePicker_ValueChanged;
            endTimePicker.ValueChanged += EndTimePicker_ValueChanged;
        }


        private void EndTimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            var time = (DateTime)e.NewValue;
            var ttm = viewmodel.EditTimetableModule;
            ttm.EndTime = time.ToString("HH:mm");
        }

        private void StartTimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Console.WriteLine("change Value" + e.NewValue);
            var time = (DateTime)e.NewValue;
            var ttm = viewmodel.EditTimetableModule;
            ttm.StartTime = time.ToString("HH:mm");
        }

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
            if (Parent is Popup)
            {
                var chooser = new ModuleEditorChooser();
                chooser.viewmodel.EditTimetableModule = viewmodel.EditTimetableModule;

                ((Popup)Parent).Child = chooser;
            }
        }
    }

}
