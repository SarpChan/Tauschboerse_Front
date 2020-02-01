using Frontend.Models;
using Frontend.ViewModel;
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

namespace Frontend.View.Windows
{
    /// <summary>
    /// Interaction logic for CreateSwapOffer_Dialog.xaml
    /// </summary>
    public partial class CreateSwapOffer_Dialog : Window
    {
        public CreateSwapOffer_Dialog()
        {
            InitializeComponent();
        }

        public void CourseSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems != null && e.AddedItems.Count > 0)
            {
                ComboBox comboBox = (ComboBox)sender;
                SwapOfferCourse selectedItem = comboBox.SelectedItem as SwapOfferCourse;
                ((SwapOfferDialogViewModel)WrapperGrid.DataContext).CourseSelectionChanged(selectedItem);
                //combo_courseTypeList.IsEnabled = true;
            } 
        }

        public void CourseTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                ComboBox comboBox = (ComboBox)sender;
                SwapOfferCourse selectedItem = comboBox.SelectedItem as SwapOfferCourse;
                ((SwapOfferDialogViewModel)WrapperGrid.DataContext).CourseTypeSelectionChanged(selectedItem);
            }
        }
        public void GroupSelect(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                ComboBox comboBox = (ComboBox)sender;
                SwapOfferGroup selectedItem = comboBox.SelectedItem as SwapOfferGroup;
                ((SwapOfferDialogViewModel)WrapperGrid.DataContext).GroupSelect(selectedItem);
            }
        }

        public void Create(object sender, RoutedEventArgs e)
        {
            ((SwapOfferDialogViewModel)WrapperGrid.DataContext).CreateSwapOffer();
            Visibility = Visibility.Collapsed;
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
