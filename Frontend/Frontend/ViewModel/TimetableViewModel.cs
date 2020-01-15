using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class TimetableViewModel : ViewModelBase
    {
        private ModuleListModel moduleListModel = ModuleListModel.Instance;
        private TimetableRowListModel rowListModel = new TimetableRowListModel();
        private DayListModel dayListModel = new DayListModel();
        private TaskFactory taskFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

        public TimetableViewModel()
        {

            Console.WriteLine(this.GetHashCode());
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

            moduleListModel.ModuleList.CollectionChanged += this.OnCollectionChanged;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

           
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (TimetableModule item in e.NewItems) { _ModuleList.Add(item); }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (TimetableModule item in e.OldItems) { _ModuleList.Remove(item); }
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        _ModuleList.Clear();
                        break;
                    default:
                        throw new ArgumentException("Unbehandelter TupelHaufen-Change " + e.Action.ToString());
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

            Console.WriteLine("I was here \n");

            TimetableModule add = new TimetableModule()

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
        private ObservableCollection<TimetableModule> _ModuleList = new ObservableCollection<TimetableModule>();
        public ObservableCollection<TimetableModule> ModuleList
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
