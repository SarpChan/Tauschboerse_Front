using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace Frontend.View
{
    /// <summary>
    /// Interaktionslogik für PythonUpload.xaml
    /// </summary>
    public partial class PythonUpload : Page
    {
        public PythonUpload()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextBlProperty =
        DependencyProperty.RegisterAttached("TextBl", typeof(string), typeof(Extensions), new PropertyMetadata(default(string)));
        public static void SetTextBl(UIElement element, string value)
        {
            element.SetValue(TextBlProperty, value);
            filenameScript.Text = value;
        }
        
        public static string GetTextBl(UIElement element)
        {
            return (string)element.GetValue(TextBlProperty);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UploadPythonscriptButton_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SavePythonCodeButton_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void upload_script(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"c:";

            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader stream = new StreamReader(openFileDialog.FileName))
                {
                    filenameScript.Text = openFileDialog.SafeFileName;
                }
            }
        }
    }
}
