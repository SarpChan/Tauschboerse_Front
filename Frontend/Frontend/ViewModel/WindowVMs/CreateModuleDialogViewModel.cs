using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class CreateModuleDialogViewModel : ViewModelBase
    {
        private APIClient ApiClient = APIClient.Instance;
        private ModuleListModel ModuleListModel = ModuleListModel.Instance;

        #region Properties

        private TimetableModule _EditTimetableModule = new TimetableModule();
        public TimetableModule EditTimetableModule { 
            get{ return _EditTimetableModule; } 
            set { _EditTimetableModule = value;
            } 
        }


        #endregion

        public CreateModuleDialogViewModel()
        {

        }

        #region Commands
        private ICommand _CreateModuleCommand;
        public ICommand CreateModuleCommand
        {
            get

            {
                if (_CreateModuleCommand == null)
                { 
                    _CreateModuleCommand = new ActionCommand(dummy => this.CreateModule(), null);
                }
                return _CreateModuleCommand;
            }
        }
        #endregion



        private void CreateModule()
        {
            Console.WriteLine("CREATE Module("+EditTimetableModule.GetHashCode()+")");
            Console.WriteLine("with Propertys \n ST: " + EditTimetableModule.StartTime + " ET:" + EditTimetableModule.EndTime+"WD:"+EditTimetableModule.Day);
            Console.WriteLine("Name :" + EditTimetableModule.CourseName + "PersonName :" + EditTimetableModule.PersonName + "G : " + EditTimetableModule.GroupChar);
            ModuleListModel.AddModule(EditTimetableModule);
        }

    }
}
