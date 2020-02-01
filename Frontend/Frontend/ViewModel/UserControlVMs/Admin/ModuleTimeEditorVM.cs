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
    class ModuleTimeEditorVM : ModuleEditorVM
    {

        private APIClient apiClient = APIClient.Instance;
        private ModuleListModel moduleListModel = ModuleListModel.Instance;

        #region Properties
  
        private ObservableCollection<string> _Weekdays = new ObservableCollection<string>(Globals.WeekdaysAbbreviation.Take(Globals.weekdays));
        public ObservableCollection<string> Weekdays {get { return _Weekdays; } set { _Weekdays = value; } }

        #endregion

        public ModuleTimeEditorVM()
        {

        }

        #region ICommand
        private ICommand _ChangeDayCommand;
        public ICommand ChangeDayCommand
        {
            get
            {
                if (_ChangeDayCommand == null)
                {
                    _ChangeDayCommand = new ActionCommand(param => ChangeDay(param), null);
                }
                return _ChangeDayCommand;
            }
        }

        #endregion

        /// <summary>
        /// Andert den Tag des EditTTM
        /// </summary>
        /// <param name="param">(String) der Tag</param>
        public void ChangeDay(object param)
        {
            var dayStr = (string)param;
            int count = 0;
            foreach(string d in _Weekdays)
            {
                if (dayStr.Equals(d))
                {
                    Console.WriteLine("Change Day" + count);
                    EditTimetableModule.Day = Convert.ToString(count);
                }
                count++;
            }
        }
    }
}
