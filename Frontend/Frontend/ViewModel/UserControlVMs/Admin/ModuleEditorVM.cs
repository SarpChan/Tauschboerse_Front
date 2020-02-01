using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    abstract class ModuleEditorVM : ViewModelBase
    {
        private TimetableModule _TimetableModuleBackUp;
        private TimetableModule _EditTimetableModule;
        public TimetableModule EditTimetableModule
        {
            get { return _EditTimetableModule; }
            set
            {
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
                    _SaveCommand = new ActionCommand(dummy => this.Save(), null);
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
        /// <summary>
        /// speichet bzw schickt es an den Server das TTM das veraendert wurde,
        /// schlaegt das fehl werden die aenderungen zurueck gesetzt 
        /// </summary>
        public async void Save()
        {
            //Hier APIclient ansprechen 
            if (EditTimetableModule != null)
            {
                try
                {
                    await SendChangesToServerAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    DiscardAllhanges();
                }
            }

        }

        private async Task SendChangesToServerAsync()
        {
            
            APIClient apiClient = APIClient.Instance;
            string json = JsonConvert.SerializeObject(EditTimetableModule);
            var response = await apiClient.NewPOSTRequest("rest/lists/timetableUpdate", json);
            if ((int)response.StatusCode >= 400) return;
        }

        /// <summary>
        /// setzt alle aenderungen des EditTTM zurueck (mit hilfe des BackupTTMs)
        /// </summary>
        public void DiscardAllhanges()
        {
            _EditTimetableModule.ReplaceData(_TimetableModuleBackUp);
        }
    }
}
