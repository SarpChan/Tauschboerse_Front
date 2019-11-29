using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    /// <summary>
    /// Interaction logic for TopBar.xaml
    /// Funktioniert aktuell nicht, weil ich nicht weiß wie man das mit den multiplen ICommands richtig macht in der RootPage.xaml
    /// </summary>
    public partial class TopBar : UserControl
    {
        public TopBar()
        {
            InitializeComponent();
        }

        #region commands
        public ICommand TB_LogoButtonCommand
        {
            get { return (ICommand)GetValue(TB_LogoButtonCommandProperty); }
            set { SetValue(TB_LogoButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TB_LogoButtonCommandProperty =
            DependencyProperty.Register("TB_LogoButtonCommand", typeof(ICommand), typeof(TB_LogoButton), new UIPropertyMetadata(null));
        
        public ICommand TB_LogoutButtonCommand
        {
            get { return (ICommand)GetValue(TB_LogoutButtonCommandProperty); }
            set { SetValue(TB_LogoutButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TB_LogoutButtonCommandProperty =
            DependencyProperty.Register("TB_LogoutButtonCommand", typeof(ICommand), typeof(TB_LogoutButton), new UIPropertyMetadata(null));
        #endregion
    }
}
