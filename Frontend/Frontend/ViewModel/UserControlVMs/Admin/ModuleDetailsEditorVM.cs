using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class ModuleDetailsEditorVM : ModuleEditorVM
    {

        private APIClient apiClient = APIClient.Instance;
        private ModuleListModel moduleListModel = ModuleListModel.Instance;

        #region Propertie

        #endregion

        public ModuleDetailsEditorVM()
        {
            Console.WriteLine("CREATE CreateModuleDialogViewModel");

            
        }
    }
}
