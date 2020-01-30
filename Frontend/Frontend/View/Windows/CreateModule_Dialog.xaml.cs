using Frontend.Models;
using Frontend.UserControls;
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

namespace Frontend.UserControls
{
    public partial class CreateModule_Dialog : Window
    {
        public CreateModule_Dialog()
        {
            InitializeComponent();

            TimetableModule ttm = viewmodel.EditTimetableModule;
            moduleTimeEditor.viewmodel.EditTimetableModule = ttm;
            moduleDetailsEditor.viewmodel.EditTimetableModule = ttm;
            moduleTypEditor.viewmodel.EditTimetableModule = ttm;
            moduleMainInformationEditor.viewmodel.EditTimetableModule = ttm;

        }

        private void CloWi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
