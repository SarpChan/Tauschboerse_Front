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

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for TimetableItem.xaml
    /// </summary>
    public partial class TimetableItem : UserControl
    {
        public TimetableItem()
        {
            InitializeComponent();
        }


        public string RoomNumber { 
            get { 
                return (string)GetValue(RoomNumberProperty); 
            } 
            set { 
                SetValue(RoomNumberProperty, value); 
            } 
        }
        public static readonly DependencyProperty RoomNumberProperty = DependencyProperty.Register("RoomNumber", typeof(string), typeof(TimetableItem), new UIPropertyMetadata(null));

        public string PersonName { get { return (string)GetValue(PersonNameProperty); } set { SetValue(PersonNameProperty, value); } }
        public static readonly DependencyProperty PersonNameProperty = DependencyProperty.Register("PersonName", typeof(string), typeof(TimetableItem), new UIPropertyMetadata(null));

        public string CourseName { get { return (string)GetValue(CourseNameProperty); } set { SetValue(CourseNameProperty, value); } }
        public static readonly DependencyProperty CourseNameProperty = DependencyProperty.Register("CourseName", typeof(string), typeof(TimetableItem), new UIPropertyMetadata(null));

        public string ID { get { return (string)GetValue(IDProperty); } set { SetValue(IDProperty, value); } }
        public static readonly DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(string), typeof(TimetableItem), new UIPropertyMetadata(null));

        public string Color { get { return (string)GetValue(ColorProperty); } set { SetValue(ColorProperty, value); } }
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(string), typeof(TimetableItem), new UIPropertyMetadata(null));

    }
}
