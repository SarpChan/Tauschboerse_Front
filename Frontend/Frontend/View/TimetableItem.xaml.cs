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
            /*
             * 
             * 
             */
        }

        #region properties

        public ModuleDummy Module
        {
            get
            {
                return (ModuleDummy)GetValue(ModuleProperty);
            }
            set
            {
                SetValue(ModuleProperty, value);
            }
        }
        public static readonly DependencyProperty ModuleProperty = DependencyProperty.Register("Module", typeof(ModuleDummy), typeof(TimetableItem), new UIPropertyMetadata(null));

        public double ItemWidth {
            get {
                return (double)GetValue(ItemWidthProperty); 
            } 
            set { 
                SetValue(ItemWidthProperty, value); 
            } 
        }
        public static readonly DependencyProperty ItemWidthProperty = DependencyProperty.Register("ItemWidth", typeof(double), typeof(TimetableItem), new UIPropertyMetadata(null));

        public double TimeWidth { get { return (double)GetValue(TimeWidthProperty); } set { SetValue(TimeWidthProperty, value); } }
        public static readonly DependencyProperty TimeWidthProperty = DependencyProperty.Register("TimeWidth", typeof(double), typeof(TimetableItem), new UIPropertyMetadata(null));

        public double TotalWidth { get { return (double)GetValue(TotalWidthProperty); } set { SetValue(TimeWidthProperty, value); } }
        public static readonly DependencyProperty TotalWidthProperty = DependencyProperty.Register("TotalWidth", typeof(double), typeof(TimetableItem), new UIPropertyMetadata(null));

        public double TotalHeight { get { return (double)GetValue(TotalHeightProperty); } set { SetValue(TimeWidthProperty, value); } }
        public static readonly DependencyProperty TotalHeightProperty = DependencyProperty.Register("TotalHeight", typeof(double), typeof(TimetableItem), new UIPropertyMetadata(null));


        public string TimeStart { get { return (string)GetValue(TimeStartProperty); } set { SetValue(TimeStartProperty, value); } }
        public static readonly DependencyProperty TimeStartProperty = DependencyProperty.Register("TimeStart", typeof(string), typeof(TimetableItem), new UIPropertyMetadata(null));

        public string TimeEnd { get { return (string)GetValue(TimeEndProperty); } set { SetValue(TimeEndProperty, value); } }
        public static readonly DependencyProperty TimeEndProperty = DependencyProperty.Register("TimeEnd", typeof(string), typeof(TimetableItem), new UIPropertyMetadata(null));

        public string Day { get { return (string)GetValue(DayProperty); } set { SetValue(DayProperty, value); } }
        public static readonly DependencyProperty DayProperty = DependencyProperty.Register("Day", typeof(string), typeof(TimetableItem), new UIPropertyMetadata(null));


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
        
        
        #endregion
    }
}
