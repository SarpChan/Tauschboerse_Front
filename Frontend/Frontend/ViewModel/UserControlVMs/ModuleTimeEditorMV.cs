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
    class ModuleTimeEditorMV : ViewModelBase
    {

        private APIClient apiClient = APIClient.Instance;
        private ModuleListModel moduleListModel = ModuleListModel.Instance;

        #region Properties
        private TimetableModule _EditTimetableModule;
        public TimetableModule EditTimetableModule
        {
            get { return _EditTimetableModule; }
            set { _EditTimetableModule = value; }
        }

        private string _Color;
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        private static string[] _Weekdays = Globals.Weekdays;
        public static string[] Weekdays{get { return _Weekdays; }}

        #endregion

        public ModuleTimeEditorMV()
        {

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
