using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using Frontend.Helpers;
using System;

namespace Frontend.UserControls
{
    public partial class SavePythonCodeButton : UserControl

        
    {  
        public SavePythonCodeButton() { InitializeComponent(); }
        public ICommand SavePythonCodeButtonCommand
        {
            get { return (ICommand)GetValue(SavePythonCodeButtonCommandProperty); }
            set { SetValue(SavePythonCodeButtonCommandProperty, value); }
        }
        public static readonly DependencyProperty SavePythonCodeButtonCommandProperty =
            DependencyProperty.Register("SavePythonCodeButtonCommand", typeof(ICommand), typeof(SavePythonCodeButton), new UIPropertyMetadata(null));
        
        /// <summary>
        /// This method saves the script into c:/users/name/
        /// </summary>
        /// <param name="sender">standard</param>
        /// <param name="e">standard</param>
        private void save_script(object sender, RoutedEventArgs e)
        {
            string codename = textblockName.Text;
            string codeblock = textblockCode.Text;
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)+"\\";
            path += codename + ".py";
            
           
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@path))
            {
                file.Write(codeblock);
            }
            sendPythonCodeToServerAsync(path);

        }

      
        /// <summary>
        /// this method sends the path of a file to the server
        /// </summary>
        /// <param name="path"> this is the path of the file</param>
        /// <returns></returns>
        private async Task sendPythonCodeToServerAsync(string path)
        {

            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewFileUploadRequest("/rest/pyScript/upload", path);
            if ((int)response.StatusCode >= 400) return;

        }
    }
}
