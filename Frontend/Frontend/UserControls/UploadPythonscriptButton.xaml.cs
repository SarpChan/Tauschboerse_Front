﻿using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using Frontend.Helpers;
using ToastNotifications.Messages;

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
        /// <summary>
        /// this method lets the user upload an existing file
        /// </summary>
        /// <param name="sender">standard</param>
        /// <param name="e">standard</param>
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
        
        /// <summary>
        /// this method sends the path of a file to the server
        /// </summary>
        /// <param name="path"> this is the path of the file</param>
        /// <returns></returns>
        private async Task sendPythonCodeToServerAsync(string path)
        {

            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewFileUploadRequest("/rest/pyScript/upload", path);

            if ((int)response.StatusCode >= 400)
            {
                App.notifier.ShowError("Fehler beim Upload!");
                return;
            }
            App.notifier.ShowSuccess("Datei hochgeladen!");
        }

    }
}
