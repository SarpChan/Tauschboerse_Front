using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for SelectionBar.xaml
    /// </summary>
    public partial class SelectionBar : UserControl
    {

        /*
         * TODO: Funktioniert noch nicht. AmountOfElements bewirkt nichts, wenn in RootPage gesetzt
         */
        public SelectionBar()
        {
            InitializeComponent();
        }

        private ObservableCollection<Button> _buttonsList = new ObservableCollection<Button>();
        public ObservableCollection<Button> ButtonsList
        {
            get { return _buttonsList; }
        }

        public int AmountOfElements
        {
            get { return (int)GetValue(AmountOfElementsProperty); }
            set { SetValue(AmountOfElementsProperty, value); CreateSelectionBar(); }
        }
        public static readonly DependencyProperty AmountOfElementsProperty =
            DependencyProperty.Register("AmountOfElements", typeof(int), typeof(SelectionBar), new UIPropertyMetadata(null));

        private void CreateSelectionBar()
        {
            Console.WriteLine("Start init SelectionBar. Amount=" + AmountOfElements);
            Style style = Application.Current.FindResource("SelectionBarButton") as Style;
            for (int i = AmountOfElements; i > 0; i--)
            {
                Button AddButton = new Button();
                AddButton.Tag = "Button #" + i;
                AddButton.Style = style;
                ButtonsList.Add(new Button());
                Console.WriteLine("i=" + i);
            }
        }
    }

}
