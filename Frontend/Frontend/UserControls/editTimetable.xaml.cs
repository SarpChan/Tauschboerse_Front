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
    /// Interaktionslogik für editTimetable.xaml
    /// </summary>
    public partial class EditTimetable : UserControl
    {
        public EditTimetable()
        {
            InitializeComponent();
        }

        public ICommand TT_SaveButtonCommand
        {
            get { return (ICommand)GetValue(TT_SaveButtonCommandProperty); }
            set { SetValue(TT_SaveButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TT_SaveButtonCommandProperty =
            DependencyProperty.Register("TT_SaveButtonCommand", typeof(ICommand), typeof(EditTimetable), new UIPropertyMetadata(null));

        public ICommand TT_TimeButtonCommand
        {
            get { return (ICommand)GetValue(TT_TimeButtonCommandProperty); }
            set { SetValue(TT_TimeButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TT_TimeButtonCommandProperty =
            DependencyProperty.Register("TT_SaveButtonCommand", typeof(ICommand), typeof(EditTimetable), new UIPropertyMetadata(null));

        public ICommand TT_DetailButtonCommand
        {
            get { return (ICommand)GetValue(TT_DetailButtonCommandProperty); }
            set { SetValue(TT_DetailButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TT_DetailButtonCommandProperty =
            DependencyProperty.Register("TT_SaveButtonCommand", typeof(ICommand), typeof(EditTimetable), new UIPropertyMetadata(null));
    }
}
