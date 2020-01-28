using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class TB_LogoButton : UserControl
    {
        public TB_LogoButton() { InitializeComponent(); }
        public ICommand TB_LogoButtonCommand
        {
            get { return (ICommand)GetValue(TB_LogoButtonCommandProperty); }
            set { SetValue(TB_LogoButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty TB_LogoButtonCommandProperty =
            DependencyProperty.Register("TB_LogoButtonCommand", typeof(ICommand), typeof(TB_LogoButton), new UIPropertyMetadata(null));
    }
}
