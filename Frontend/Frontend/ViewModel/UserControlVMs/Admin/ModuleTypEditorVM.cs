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
    class ModuleTypEditorVM : ModuleEditorVM
    {
        #region Properties

        private IEnumerable<TimetableModule.ModuleType> _Types = Enum.GetValues(typeof(TimetableModule.ModuleType)).Cast<TimetableModule.ModuleType>();
        public IEnumerable<TimetableModule.ModuleType> Types { get { return _Types; }}
        #endregion

        public ModuleTypEditorVM()
        {

        }

        #region Commands

        private ICommand _ChangeTypeCommand;
        public ICommand ChangeTypeCommand
        {
            get
            {
                if (_ChangeTypeCommand == null)
                {
                    _ChangeTypeCommand = new ActionCommand(param => ChangeType(param), null);
                }
                return _ChangeTypeCommand;
            }
        }

        /// <summary>
        /// Andet den Typen des EditTTM
        /// </summary>
        /// <param name="param">(TimetableModule.ModuleType) type</param>
        private void ChangeType(object param)
        {
            var type = (TimetableModule.ModuleType)param;
            EditTimetableModule.Type = type;
        }

        #endregion


    }
}
