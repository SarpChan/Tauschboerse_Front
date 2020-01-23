using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class ModuleEditorVM : ViewModelBase
    {


        private APIClient apiClient = APIClient.Instance;
        private ModuleListModel moduleListModel = ModuleListModel.Instance;

        private TimetableModule _EditTimetableModule;
        public TimetableModule EditTimetableModule
        {
            get { return _EditTimetableModule; }
            set {
                Console.WriteLine("set ttm" + value.GetHashCode());
                _EditTimetableModule = value; }
        }

        private string _Color;
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        #region ICommand
        private ICommand _SaveTimeCommand;

        public ICommand SaveTimeCommand
        {
            get
            {
                if (_SaveTimeCommand == null)
                {
                    _SaveTimeCommand = new ActionCommand(dummy => this.SaveTime(), null);
                }
                return _SaveTimeCommand;
            }
        }

        #endregion

        public void SaveTime()
        {
            //Hier APIclient ansprechen

            if (EditTimetableModule != null && !moduleListModel.ModuleList.Contains(EditTimetableModule))
            {
                moduleListModel.ModuleList.Add(EditTimetableModule);
            }

        }
    }
}
