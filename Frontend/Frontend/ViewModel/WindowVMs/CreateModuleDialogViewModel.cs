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

        private Dictionary<long, string> _FieldOfStudyDict = new Dictionary<long, string>();
        public Dictionary<long, string> FieldOfStudyDict
        {
            get { return _FieldOfStudyDict; }
            set { _FieldOfStudyDict = value;}
        }

        private Dictionary<long, string> _StudyProgramDict = new Dictionary<long, string>();
        public Dictionary<long,string> StudyProgramDict
        {
            get { return _StudyProgramDict; }
            set { _StudyProgramDict = value; }
        }


        private TimetableModule _EditTimetableModule = new TimetableModule();
        public TimetableModule EditTimetableModule { 
            get{ return _EditTimetableModule; } 
            set { _EditTimetableModule = value;
            } 
        }


        #endregion

        public CreateModuleDialogViewModel()
        {
            Console.WriteLine("CREATE CreateModuleDialogViewModel");

            _StudyProgramDict.Add(17, "Informatik");
            _StudyProgramDict.Add(42, "Schachwissenschaften");

            _FieldOfStudyDict.Add(1,"Medieninformatik");
            _FieldOfStudyDict.Add(2, "Medieninformatik 2 - Hilfe nicht noch mal");
            _FieldOfStudyDict.Add(3, "Medieninformatik 3 - Ist das ein Scherz");
            _FieldOfStudyDict.Add(4, "Medieninformatik 17 - Ich will nicht mehr");

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
            Console.WriteLine("CREATE Module");
            ModuleListModel.AddModule(EditTimetableModule);
        }

    }
}
