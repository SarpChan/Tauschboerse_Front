using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<string> _Weekdays = new ObservableCollection<string>(Globals.Weekdays.Take(Globals.weekdays));
        public ObservableCollection<string> Weekdays {get { return _Weekdays; } set { _Weekdays = value; } }

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

        private ICommand _ChangeDayCommand;
        public ICommand ChangeDayCommand
        {
            get
            {
                if (_ChangeDayCommand == null)
                {
                    //_ChangeDayCommand = new ActionCommand((int i) => ChangeDay(i), null);
                }
                return _ChangeDayCommand;
            }
        }

        #endregion

        public void ChangeDay(int index)
        {
            Console.WriteLine(index);
            EditTimetableModule.Day = Convert.ToString(index);
        }


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
