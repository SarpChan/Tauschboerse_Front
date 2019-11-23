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

namespace Frontend.View
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {

        public static readonly string[] Wochentage = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };

        public TimetablePage()
        {
            InitializeComponent();
            int noRows = 5;
            for(int i = 0; i < 5; i++)
            {

                /*
                DataGridTextColumn newColumn = new DataGridTextColumn();
                newColumn.Header = Wochentage[i];
                newColumn.Binding = new Binding(Wochentage[i]);
                Stundenplan.Columns.Add(newColumn);*/
                //ColumnDefinition columnDefinition = new ColumnDefinition();
                //columnDefinition.Width = new GridLength("0." + (100 / noRows) + "*";
                // local:GridHelpers.RowCount="{Binding RowCount}" local:GridHelpers.ColumnCount="{Binding ColumnCount}"
                //https://rachel53461.wordpress.com/2011/09/17/wpf-grids-rowcolumn-count-properties/
                //Stundenplan.ColumnDefinitions.Add(columnDefinition);
                //TextBlock t = new TextBlock();
                //t.Text = i+"%";
                //Grid.SetColumn(t, i);
                //Stundenplan.Children.Add(t);
            }
        }

        private void Timetable_Button_Click(object sender, RoutedEventArgs e)
        {
            TimetablePage timetablePage = new TimetablePage();
            this.NavigationService.Navigate(timetablePage);
        }
        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            this.NavigationService.Navigate(homePage);
        }

        private void TimetableItem_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
