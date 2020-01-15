using Frontend.Helpers;
using Frontend.Models;
using Frontend.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows;
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

            moduleListModel.ModuleList.CollectionChanged += this.OnCollectionChanged;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

           
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        OnModuleAdd();
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        OnModuleRemove();
                    break;
                    case NotifyCollectionChangedAction.Reset:
                        OnModuleClear();
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

            };

            //moduleListModel.AddModule(add);

            //ModuleList.Add(add);


        }

        


        #endregion
        
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

        // Hilfsmethode für AddEinkaufCommand

        void AddModule()
        {


            /*
             * Annahme: Model ist nicht "observer-fähig" (z.B: Datenbank)
             * daher synchrone Pflege von Model UND ViewModel hier - besser: 
             * Model mit INotifyPropertyChanged und Änderungen observieren,
             * Anpassung des ViewModels bei Änderungsmitteilung vom Model
             */
            /**
             * Console.WriteLine("I was here");
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
     */
        }



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

        private ICommand _DialogOpen_ButtonCommand;
        public ICommand DialogOpenCommand
        {
            get
            {
                if(_DialogOpen_ButtonCommand == null)
                {
                    _DialogOpen_ButtonCommand = new ActionCommand(dummy => this.OpenDialog());
                }
                return _DialogOpen_ButtonCommand;
            }
        }

     
        //Hilfsmethode fuer OpenDialogCommand
        private void OpenDialog()
        {
            SO_Dialog swapDialog = new SO_Dialog();
            swapDialog.Show();
            swapDialog.Topmost = true;

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
