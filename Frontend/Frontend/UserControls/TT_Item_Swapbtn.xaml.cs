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

        /// <summary>
        /// Ein neues Dialogfenster zum Tauschen soll erstellt,
        /// geöffnet und mit allen Daten über den Aufruf FillDialog() gefüllt werden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDialog(object sender, RoutedEventArgs e)
        {
            d = new SO_Dialog();
            d.Show();
            d.Topmost = true;
            FillDialog();
           
            
        }

        /// <summary>
        /// Eine Liste mit allen Gruppen, die zum jeweiligen Fach gehören und die der User noch wählen kann, 
        /// werden aus dem Backend geholt
        /// </summary>
        private async void GetGroupLstAsync()
        {
            Dictionary<long, char> Groups;
            List<SwapOfferGroup> lst = new List<SwapOfferGroup>();
          
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewGETRequest("rest/group/dropdowncollection/" + d.FromGroupID);
            Groups = JsonConvert.DeserializeObject<Dictionary<long, char>>(response.Content);

            foreach (KeyValuePair<long, char> keyValue in Groups)
            {
                lst.Add(new SwapOfferGroup { Char = keyValue.Value, Id = keyValue.Key });
            }
          
            d.ToGroup.ItemsSource = lst;

        }

        /// <summary>
        /// Das geöffnete Dialogfenster wird mit den richtigen Daten gefüllt:
        /// Kursname, Kurstyp und die Gruppe, in der der User ist
        /// Zudem wird die GruppenID gespeichert
        /// </summary>
        private void FillDialog()
        {
           
            d.CourseName.Text = item.Module.Module.CourseName;
            d.CourseType.Text = item.Module.Module.Type.ToString();
            d.FromGroup.Text = item.Module.Module.GroupChar;      
            d.FromGroupID = item.Module.Module.ID;
            GetGroupLstAsync();

           
        }
    }
}
