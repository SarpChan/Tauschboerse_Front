using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    public class PythonUploadViewModel
    {
        public PythonUploadViewModel()
        {
            //TT_SaveButtonCommand = new ICommand(new Action<object>(ShowMessage));
        }

        private ICommand pythonscriptUpload_ButtonCommand;

        public ICommand UploadPythonscriptCommand
        {
            get { return pythonscriptUpload_ButtonCommand; }
            set { pythonscriptUpload_ButtonCommand = value; }
        }

    }
}
