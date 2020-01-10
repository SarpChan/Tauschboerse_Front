using Frontend.Models;
using Frontend.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Frontend
{
    class TimetableViewModel : ViewModelBase
    {
        private ModuleListModel moduleListModel = new ModuleListModel();
        private TimetableRowListModel rowListModel = new TimetableRowListModel();
        private DayListModel dayListModel = new DayListModel();
        private SO_Dialog dialog = new SO_Dialog();

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
            foreach (var day in dayListModel.DayList)
            {
                _DayList.Add(day);
            }
        }

        #region Commands

        private ICommand _AddModuleCommand;
        public ICommand AddModuleCommand
        {
            get
            {
                if (_AddModuleCommand == null)
                {
                    // 1. Argument: Kommando-Effekt (Execute), 2. Argument: Bedingung "Kommando aktiv?" (CanExecute)
                    _AddModuleCommand = new ActionCommand(dummy => this.AddModule(), null);
                }
                return _AddModuleCommand;
            }
        }

     

        // Hilfsmethode für AddEinkaufCommand
        private void AddModule()
        {


            /*
             * Annahme: Model ist nicht "observer-fähig" (z.B: Datenbank)
             * daher synchrone Pflege von Model UND ViewModel hier - besser: 
             * Model mit INotifyPropertyChanged und Änderungen observieren,
             * Anpassung des ViewModels bei Änderungsmitteilung vom Model
             */
            Console.WriteLine("I was here");
            ModuleDummy add = new ModuleDummy()
            {
                ID = "420",
                StartTime = "08:15",
                EndTime = "12:30",
                Day = "4",
                PersonName = "Nicky",
                RoomNumber = "D40",
                CourseName = "TEST",
                GroupChar = 'Z',
                Color = "#FFF4A233"
            };
            moduleListModel.AddModule(add);
            ModuleList.Add(add);

        }

        #endregion


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
