using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
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

        public async void SaveTime()
        {
            //Hier APIclient ansprechen
            Console.WriteLine("hhsadjbasidb");
            if (EditTimetableModule != null)
            {
                try
                {
                    await SendChangesToServerAsync();
                    moduleListModel.ModuleList.Add(EditTimetableModule);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    DiscardAllhanges();
                }
            }

        }

        private async Task SendChangesToServerAsync()
        {
            Console.WriteLine(EditTimetableModule.StartTime);
            Console.WriteLine(EditTimetableModule.EndTime);

            APIClient apiClient = APIClient.Instance;
            string json = JsonConvert.SerializeObject(EditTimetableModule);
            var response = await apiClient.NewPOSTRequest("rest/lists/timetableUpdate", json);
            
            if ((int)response.StatusCode >= 400) return;
            Console.WriteLine("[SAVE TIMETABLE]"+response.Content.ToString());
        }

            public void DiscardAllhanges()
        {
            Console.WriteLine("Discard Changes");
            _EditTimetableModule.ReplaceData(_TimetableModuleBackUp);
        }
    }
}
