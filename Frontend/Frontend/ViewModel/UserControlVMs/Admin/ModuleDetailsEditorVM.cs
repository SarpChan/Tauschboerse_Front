using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class ModuleDetailsEditorVM : ModuleEditorVM
    {

        private APIClient apiClient = APIClient.Instance;
        private ModuleListModel moduleListModel = ModuleListModel.Instance;

        #region Properties


        #endregion

        public ModuleDetailsEditorVM()
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

        public void ChangeDay(object param)
        {
            int index = (int)param;
            Console.WriteLine(index);
            EditTimetableModule.Day = Convert.ToString(index);
        }
    }
}
