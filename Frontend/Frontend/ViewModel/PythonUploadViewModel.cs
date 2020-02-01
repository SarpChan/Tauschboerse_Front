using Frontend.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class PythonUploadViewModel : ViewModelBase
    {
        public PythonUploadViewModel()
        {
            //TT_SaveButtonCommand = new ICommand(new Action<object>(ShowMessage));
        }

        private string textBlockValue;
        public string TextBlockValue
        {
            get { return textBlockValue; }
            set
            {
                if (textBlockValue != value)
                {
                    textBlockValue = value;
                    OnPropertyChanged("TextBlockValue");
                }
            }
        }

        private ICommand pythonscriptUpload_ButtonCommand;

        public ICommand UploadPythonscriptCommand
        {
            get { return pythonscriptUpload_ButtonCommand; 
            }
            set { pythonscriptUpload_ButtonCommand = value; }
        }
        private ICommand pythoncodeSave_ButtonCommand;

        public ICommand SavePythonCodeCommand
        {
            get { return pythoncodeSave_ButtonCommand; }
            set { pythoncodeSave_ButtonCommand = value; }
        }


    }
}
