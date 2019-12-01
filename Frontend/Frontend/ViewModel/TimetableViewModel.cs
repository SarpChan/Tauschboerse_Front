using Frontend.Models;
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
        private TimetableRowListModel rowListModel = new TimetableRowListModel();
        private DayListModel dayListModel = new DayListModel();

        public TimetableViewModel()
        {
            foreach( var ding in moduleListModel.ModuleList)
            {
                _ModuleList.Add(ding);
            }
            foreach (var row in rowListModel.RowList)
            {
                _RowList.Add(row);
            }
        }

        #region Properties

        private ObservableCollection<ModuleDummy> _ModuleList = new ObservableCollection<ModuleDummy>();
        public ObservableCollection<ModuleDummy> ModuleList
        {
            get { return _ModuleList;  }
        }

        private ObservableCollection<RowModel> _RowList = new ObservableCollection<RowModel>();
        public ObservableCollection<RowModel> RowList
        {
            get { return _RowList; }
        }

        private ObservableCollection<DayModel> _DayList = new ObservableCollection<DayModel>();
        public ObservableCollection<DayModel> DayList
        {
            get { return _DayList; }
        }


        #endregion
    }
}
