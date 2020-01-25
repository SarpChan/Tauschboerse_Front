using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class ModuleDetailsEditorVM : ModuleEditorVM
    {

        protected APIClient apiClient = APIClient.Instance;
        protected ModuleListModel moduleListModel = ModuleListModel.Instance;

        #region Propertie

        #endregion

        public ModuleDetailsEditorVM()
        {
            Console.WriteLine("CREATE CreateModuleDialogViewModel");
            _RoomDict.Add(17, "D17");
            _GroupDict.Add(14, "C");
            _LectureDict.Add(17,"Ich");
            
        }

        private Dictionary<long, string> _RoomDict = new Dictionary<long, string>();
        public Dictionary<long, string> RoomDict
        {
            get { return _RoomDict; }
            set { _RoomDict = value; }
        }

        private Dictionary<long, string> _GroupDict = new Dictionary<long, string>();
        public Dictionary<long, string> GroupDict
        {
            get { return _GroupDict; }
            set { _GroupDict = value; }
        }

        private Dictionary<long, string> _LectureDict = new Dictionary<long, string>();
        public Dictionary<long, string> LectureDict
        {
            get { return _LectureDict; }
            set { _LectureDict = value; }
        }

    }
}
