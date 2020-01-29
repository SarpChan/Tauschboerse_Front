using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using Frontend.Helpers;

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

        private void upload_script(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"c:";

            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader stream = new StreamReader(openFileDialog.FileName))
                {
                    filenameScript.Text = openFileDialog.SafeFileName;
                    openFileDialog.Filter = "All Files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.Multiselect = true;
                    string path = openFileDialog.FileName;
                    sendPythonCodeToServerAsync(path);
                }
            }

           
        }

        private async Task sendPythonCodeToServerAsync(string path)
        {

            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewFileUploadRequest("/rest/pyScript/upload", path);

            if ((int)response.StatusCode >= 400) return;

        }

    }
}
