using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class SB_PythonScriptButton : UserControl
    {
        public SB_PythonScriptButton() { InitializeComponent(); }
        public ICommand SB_PythonScriptButtonCommand
        {
            get { return (ICommand)GetValue(SB_PythonScriptButtonCommandProperty); }
            set { SetValue(SB_PythonScriptButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SB_PythonScriptButtonCommandProperty =
            DependencyProperty.Register("SB_PythonScriptButtonCommand", typeof(ICommand), typeof(SB_PythonScriptButton), new UIPropertyMetadata(null));
    }
}