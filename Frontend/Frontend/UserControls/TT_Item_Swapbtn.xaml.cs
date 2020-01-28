using Frontend.Helpers;
using Frontend.Models;
using Frontend.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
       

        public TT_Item_Swapbtn()
        {
            InitializeComponent();
         
                      
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
            GetGroupLstAsync();
            
        }

        /*
         * Methode, um die Liste mit allen Gruppen aus dem Backend zu holen, die der User noch wählen kann
         */
        private async void GetGroupLstAsync()
        {
            List<Group> Groups;
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewGETRequest("rest/group/dropdowncollection/"+ d.GroupID);
            Console.WriteLine(response.Content);
            Groups = JsonConvert.DeserializeObject<List<Group>>(response.Content); // WIRFT FEHLERMELDUNG
            d.ToGroup.ItemsSource = Groups;
            
            


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
