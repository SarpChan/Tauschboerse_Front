using Frontend.Helpers;
using Frontend.Models;
using System.Collections.ObjectModel;

namespace Frontend.ViewModel
{
    class TimetableViewModel : ViewModelBase
    {
        private ModuleListModel moduleListModel = ModuleListModel.Instance;
        private TimetableRowListModel rowListModel = new TimetableRowListModel();
        private DayListModel dayListModel = new DayListModel();

        public TimetableViewModel()
        {
            foreach( var module in moduleListModel.ModuleList)
            {
                _ModuleList.Add(new TimetableViewModelModule { 
                    Module = module,
                });
            }

            CalculateInitialValues();

            foreach (var row in rowListModel.RowList)
            {
                _RowList.Add(row);
            }
            foreach (var day in dayListModel.DayList)
            {
                _DayList.Add(day);
            }
        }

        #region Methods

        private void CalculateInitialValues()
        {

        }

        private void OnStartTimeChange()
        {

        }
        private void OnEndTimeChange()
        {

        }
        private void OnDayChange()
        {

        }
        private void OnNameChange()
        {

        }
        private void OnTypeChange()
        {

        }
        private void OnModuleAdd()
        {

        }
        private void OnModuleRemove()
        {

        }
        private void OnModuleClear()
        {

        }
        #endregion

        #region Properties
        private ObservableCollection<TimetableViewModelModule> _ModuleList = new ObservableCollection<TimetableViewModelModule>();
        public ObservableCollection<TimetableViewModelModule> ModuleList
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

    class TimetableViewModelModule
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Color { get; set; }
        public TimetableModule Module { get; set; }

    }

}
