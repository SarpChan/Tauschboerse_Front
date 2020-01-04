using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.UserControls
{
    public partial class UploadPythonscriptButton : UserControl
    {
        public UploadPythonscriptButton() { InitializeComponent(); }
        public ICommand UploadPythonscriptButtonCommand
        {
            get { return (ICommand)GetValue(UploadPythonscriptButtonCommandProperty); }
            set { SetValue(UploadPythonscriptButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty UploadPythonscriptButtonCommandProperty =
            DependencyProperty.Register("UploadPythonscriptButtonCommand", typeof(ICommand), typeof(UploadPythonscriptButton), new UIPropertyMetadata(null));
    }
}
