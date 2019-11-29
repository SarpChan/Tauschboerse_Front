using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    /// <summary>
    /// Interaction logic for SideBar.xaml
    /// Funktioniert aktuell nicht, weil ich nicht weiß wie man das mit den multiplen ICommands richtig macht in der RootPage.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
        }

        #region commands
        public ICommand SB_HomeButtonCommand
        {
            get { return (ICommand)GetValue(SB_HomeButtonCommandProperty); }
            set { SetValue(SB_HomeButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_HomeButtonCommandProperty =
            DependencyProperty.Register("SB_HomeButtonCommand", typeof(ICommand), typeof(SB_HomeButton), new UIPropertyMetadata(null));
    

        public ICommand SB_TimetableButtonCommand
        {
            get { return (ICommand)GetValue(SB_TimetableButtonCommandProperty); }
            set { SetValue(SB_TimetableButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_TimetableButtonCommandProperty =
            DependencyProperty.Register("SB_TimetableButtonCommand", typeof(ICommand), typeof(SB_TimetableButton), new UIPropertyMetadata(null));
        
        public ICommand SB_SharingServiceButtonCommand
        {
            get { return (ICommand)GetValue(SB_SharingServiceButtonCommandProperty); }
            set { SetValue(SB_SharingServiceButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_SharingServiceButtonCommandProperty =
            DependencyProperty.Register("SB_SharingServiceButtonCommand", typeof(ICommand), typeof(SB_SharingServiceButton), new UIPropertyMetadata(null));
        
        public ICommand SB_PersonalDataButtonCommand
        {
            get { return (ICommand)GetValue(SB_PersonalDataButtonCommandProperty); }
            set { SetValue(SB_PersonalDataButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_PersonalDataButtonCommandProperty =
            DependencyProperty.Register("SB_PersonalDataButtonCommand", typeof(ICommand), typeof(SB_PersonalDataButton), new UIPropertyMetadata(null));

        public ICommand SB_AdminButtonCommand
            {
                get { return (ICommand)GetValue(SB_AdminButtonCommandProperty); }
                set { SetValue(SB_AdminButtonCommandProperty, value); }
            }
            public static readonly DependencyProperty SB_AdminButtonCommandProperty =
                DependencyProperty.Register("SB_AdminButtonCommand", typeof(ICommand), typeof(SB_AdminButton), new UIPropertyMetadata(null));
        #endregion
    }
}
