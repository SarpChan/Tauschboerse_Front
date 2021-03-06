﻿using Frontend.Helpers;
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

        //Voruebergehend ist die ID Random [es waere fuer des Backend wahrscheonlich beser wenn die ID Null ist da Random auch eine vorhandene ID treffen koennte]
        private TimetableModule _EditTimetableModule = new TimetableModule() { ID = new Random().Next() };
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
                    _CreateModuleCommand = new ActionCommand(dummy =>  this.CreateModule(), null);
                }
                return _CreateModuleCommand;
            }
        }
        #endregion

        TaskFactory taskFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());


        private void CreateModule()
        {
            ModuleListModel.AddModule(EditTimetableModule);
            
            
        }

    }
}
