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
    abstract class ModuleEditorVM : ViewModelBase
    {


        private APIClient apiClient = APIClient.Instance;
        private ModuleListModel moduleListModel = ModuleListModel.Instance;

        private TimetableModule _TimetableModuleBackUp;
        private TimetableModule _EditTimetableModule;
        public TimetableModule EditTimetableModule
        {
            get { return _EditTimetableModule; }
            set {
                Console.WriteLine("set ttm" + value.GetHashCode());
                _EditTimetableModule = value;
                _TimetableModuleBackUp = value.DeepCopy();
            }
        }

        private string _Color;
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        #region ICommand
        private ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new ActionCommand(dummy => this.SaveTime(), null);
                }
                return _SaveCommand;
            }
        }

        public ICommand _DiscardAllChangesCommand;
        public ICommand DiscardAllChangesCommand
        {
            get
            {
                if (_DiscardAllChangesCommand == null)
                {
                    _DiscardAllChangesCommand = new ActionCommand(param => this.DiscardAllhanges(), null);
                }
                return _DiscardAllChangesCommand;
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

        public void DiscardAllhanges()
        {
            Console.WriteLine("Discard Changes");
            _EditTimetableModule.ReplaceData(_TimetableModuleBackUp);
        }
    }
}
