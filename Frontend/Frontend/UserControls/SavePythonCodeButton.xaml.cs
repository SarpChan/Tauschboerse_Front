﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        }
    }
}
