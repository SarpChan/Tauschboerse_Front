using Frontend.Helpers;
using Frontend.Models;
using Frontend.View;
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
    /// Interaction logic for TT_Item_Swapbtn.xaml
    /// </summary>
    public partial class TT_Item_Swapbtn : UserControl
    {
        SO_Dialog d;
        GroupListModel GroupList;

        public TT_Item_Swapbtn()
        {
            InitializeComponent();
            GroupList = GroupListModel.Instance;
                      
        }

      /*
       * Methode, die vom Usercontrol aufgerufen wird, um ein neues Dialogfenster zum Tauschen erstellt und
       * dieses öffnet und mit allen Daten über den Aufruf FillDialog() füllt
       */
        private void OpenDialog(object sender, RoutedEventArgs e)
        {
            d = new SO_Dialog();
            d.Show();
            d.Topmost = true;
            FillDialog();
            
        }

        /*
         * Methode, um die Liste mit allen Gruppen aus dem Backend zu holen, die der User noch wählen kann
         */
        private async void GetGroupLstAsync()
        {
           
            APIClient apiClient = APIClient.Instance;
            var request = await apiClient.NewGETRequest("rest/");
            

        }

        /*
         * Methode, um das Dialogfenster mit den richtigen Daten zu füllen
         */
        private void FillDialog()
        {
           
            d.CourseName.Text = item.Module.Module.CourseName;
            d.TargetCourse.Text = item.Module.Module.CourseName;
            d.FromGroup.Text = item.Module.Module.GroupChar;
            
            d.GroupID = item.Module.Module.ID;

           
        }
    }
}
