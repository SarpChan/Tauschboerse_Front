using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    class TimetableViewModel : ViewModelBase
    {
        private ModuleListModel moduleListModel = new ModuleListModel();

        public TimetableViewModel()
        {
            foreach( var ding in moduleListModel.ModuleList)
            {
                _ModuleList.Add(ding);
            }
        }

        #region Properties

        private ObservableCollection<ModuleDummy> _ModuleList = new ObservableCollection<ModuleDummy>();
        public ObservableCollection<ModuleDummy> ModuleList
        {
            get { return _ModuleList;  }
        }

        #endregion
    }
}
