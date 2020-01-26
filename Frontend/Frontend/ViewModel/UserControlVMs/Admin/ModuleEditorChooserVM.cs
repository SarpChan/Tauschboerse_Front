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
    class ModuleEditorChooserVM : ModuleEditorVM
    {
        #region Commands
        private ICommand _DeleteModuleCommand;

        public ICommand DeleteModuleCommand
        {
            get
            {
                if (_DeleteModuleCommand == null)
                {
                    _DeleteModuleCommand = new ActionCommand(dummy => this.DeleteModule(), null);
                }
                return _DeleteModuleCommand;


            }
        }

        private void DeleteModule()
        {
            ModuleListModel.Instance.ModuleList.Remove(EditTimetableModule);
        }

        #endregion
    }


}
