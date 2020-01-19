using Frontend.Helpers;
using Frontend.Helpers.Calculators;
using Frontend.Helpers.Generators;
using Frontend.Helpers.Handlers;
using Frontend.Models;
using Frontend.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

        private double _TotalWidth;
        private double _TotalHeight;
        private double _TimeWitdh;

        public double TotalWidth {
            get{return _TotalWidth; }
            set {
                _TotalWidth = value;
                OnTotalWitdhChange(_TotalWidth);
            } 
        }

        public double TimeWidth { get { return _TimeWitdh; } 
            set {
                _TimeWitdh = value;
                OnTimeWidthtChange(_TimeWitdh);
            } 
        }

        public double TotalHeight { get { return _TotalHeight; } 
            set {
                _TotalHeight = value;
                OnTotalHeightChange(_TotalHeight);
            } 
        }

        public TimetableViewModel()
        {

            Console.WriteLine("NEW TIMETABLEVIEWMODEL ->  "+this.GetHashCode());
            foreach (var module in moduleListModel.ModuleList)
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
                        OnModuleAdd(sender, e);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        OnModuleRemove(sender, e);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        OnModuleClear(sender, e);
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

            Console.WriteLine("\n ADD MODULE WITH BUTTON");
            /*
	
             * Annahme: Model ist nicht "observer-fähig" (z.B: Datenbank)
	
             * daher synchrone Pflege von Model UND ViewModel hier - besser: 
	
             * Model mit INotifyPropertyChanged und Änderungen observieren,
	
             * Anpassung des ViewModels bei Änderungsmitteilung vom Model
	
             */

            TimetableModule add = new TimetableModule()

            {

                ID = ((int)(new Random().NextDouble() * 50) + 1).ToString(),

                StartTime = "08:15",

                EndTime = "12:30",

                Day = "3",

                PersonName = "Nicky",

                RoomNumber = "D40",

                CourseName = "TEST",

                GroupChar = 'Z',

            };

            moduleListModel.ModuleList.Add(add);
        }




        #endregion

        #region Methods

        private void CalculateInitialValues()
        {
            foreach (TimetableViewModelModule ttvmm in _ModuleList)
            {
                TimeToYCoordinatesConverter timeToYCoordinatesConverter = new TimeToYCoordinatesConverter();
                Inititalize_TimetableViewModelModule(ttvmm);
                
            }
        }

        private List<TimetableViewModelModule> findDependentModules(TimetableViewModelModule module, IList<TimetableViewModelModule> moduleList)
        {
            List<TimetableViewModelModule> dependencies = new List<TimetableViewModelModule>();
            foreach (TimetableViewModelModule i in moduleList)
            {
                if (i.Module.Equals(module.Module))
                {
                    continue;
                }
                else
                {
                    int startTime = TimeCoodinatesCalculator.TimeStringToInt(module.Module.StartTime);
                    int endTime = TimeCoodinatesCalculator.TimeStringToInt(module.Module.EndTime);
                    var startTimeCompare = TimeCoodinatesCalculator.TimeStringToInt(i.Module.StartTime);
                    var endTimeCompare = TimeCoodinatesCalculator.TimeStringToInt(i.Module.EndTime);
                    if ((startTime <= startTimeCompare && endTime > startTimeCompare) || (startTime < endTimeCompare && endTime >= endTimeCompare))
                    {
                        dependencies.Add(i);
                    }
                }
            }

            return dependencies;
        }

        private TimetableViewModelModule findTimetableViewModelMoudle(TimetableModule t, IList<TimetableViewModelModule> moduleList)
        {
            foreach (TimetableViewModelModule ttvmm in moduleList)
            {
                if (ttvmm.Module.Equals(t))
                {
                    return ttvmm;
                }
            }
            return null;
        }

        private void Inititalize_TimetableViewModelModule(TimetableViewModelModule ttvmm)
        {
            Console.WriteLine("\t Init ttvmm ("+this.GetHashCode()+") \n\t\t(before) ->  Color:" + ttvmm.Color +" Y:" + ttvmm.Y+
                "  X:"+ttvmm.X+"  H:"+ttvmm.Height+" W:"+ttvmm.Width);

            TimeSpan start = TimeSpan.Parse(ttvmm.Module.StartTime);
            TimeSpan end = TimeSpan.Parse(ttvmm.Module.EndTime);

            Console.WriteLine("\t\tMODULELIST LENGTH : " + moduleListModel.ModuleList.Count);

            /*Meldet die Methode OnModuleChange auf die PropertyChanged des Modules an und gibt das ttvmm als festen Parameter mit"*/
            ttvmm.Width = TimeCoodinatesCalculator.ConvertDayToItemWidth(TotalWidth, TimeWidth, ttvmm, moduleListModel.ModuleList);
            ttvmm.X = TimeCoodinatesCalculator.ConvertTimeToXCoordinates(TotalWidth, TimeWidth, int.Parse(ttvmm.Module.Day), ttvmm, moduleListModel.ModuleList);
            ttvmm.Y = TimeCoodinatesCalculator.ConvertTimeToYCoordinates(TotalHeight, start);
            ttvmm.Height = TimeCoodinatesCalculator.ItemHeightConverter(TotalHeight, start, end);
            ttvmm.Color = ColorGenerator.generateColor(ttvmm.Module.CourseName, ttvmm.Module.Type);

            Console.WriteLine("\t\t(after) ->  Color:" + ttvmm.Color + " Y:" + ttvmm.Y +
                "  X:" + ttvmm.X + "  H:" + ttvmm.Height + " W:" + ttvmm.Width);

        }

        private void BindListenerOn_TimetableViewModelModule(TimetableViewModelModule ttvmm)
        {
            ttvmm.Module.PropertyChanged += (sender, e) => OnModuleChange(sender, e, ttvmm);
        }

        private void OnTimeWidthtChange(double newValue)
        {
            foreach (TimetableViewModelModule ttvmm in _ModuleList)
            {
                ttvmm.Width = TimeCoodinatesCalculator.ConvertDayToItemWidth(TotalWidth,newValue, ttvmm, moduleListModel.ModuleList);
                ttvmm.X = TimeCoodinatesCalculator.ConvertTimeToXCoordinates(TotalWidth,newValue, int.Parse(ttvmm.Module.Day), ttvmm, moduleListModel.ModuleList);
            }
        }

        private void OnTotalHeightChange(double newValue)
        {
            foreach (TimetableViewModelModule ttvmm in _ModuleList)
            {
                TimeSpan start = TimeSpan.Parse(ttvmm.Module.StartTime);
                TimeSpan end = TimeSpan.Parse(ttvmm.Module.EndTime);

                ttvmm.Y = TimeCoodinatesCalculator.ConvertTimeToYCoordinates(newValue, start);
                ttvmm.Height = TimeCoodinatesCalculator.ItemHeightConverter(newValue, start, end);
            }
        }

        private void OnTotalWitdhChange(double newValue)
        {

            foreach(TimetableViewModelModule ttvmm in _ModuleList)
            {
                ttvmm.Width = TimeCoodinatesCalculator.ConvertDayToItemWidth(newValue, TimeWidth, ttvmm, moduleListModel.ModuleList);
                ttvmm.X = TimeCoodinatesCalculator.ConvertTimeToXCoordinates(newValue, TimeWidth, int.Parse(ttvmm.Module.Day), ttvmm, moduleListModel.ModuleList);
            }
        }

        private void OnModuleChange(object sender, PropertyChangedEventArgs e, TimetableViewModelModule ttvmm)
        {
            var args = e as PropertyChangedExtendedEventArgs;
            var ttm = sender as TimetableModule;


            switch (e.PropertyName)
            {
                case "Name": OnNameChange(ttm, args, ttvmm); break;
                case "StartTime": OnStartTimeChange(ttm, args, ttvmm); break;
                case "EndTime": OnEndTimeChange(ttm, args, ttvmm); break;
                case "Day": OnDayChange(ttm, args, ttvmm); break;
                case "Type": OnTypeChange(ttm, args, ttvmm); break;
            }
        }

        private void OnNameChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Change Name");
            Console.ForegroundColor = ConsoleColor.White;

            ttvmm.Color = ColorGenerator.generateColor(ttm.CourseName, ttm.Type);

        }
        private void OnStartTimeChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {

        }
        private void OnEndTimeChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {

        }
        private void OnDayChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {

        }
        private void OnTypeChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {
            ttvmm.Color = ColorGenerator.generateColor(ttm.CourseName, ttm.Type);
        }
        private void OnModuleAdd(object sender, NotifyCollectionChangedEventArgs e)
        {

            foreach (TimetableModule t in e.NewItems)
            {
                TimetableViewModelModule add = new TimetableViewModelModule
                {
                    Module = t
                };
                Console.WriteLine(t);
                Console.WriteLine("\t ADD MODULE: "+t.CourseName+" ->"+add);
               
                ModuleList.Add(add);
                BindListenerOn_TimetableViewModelModule(add);
                Inititalize_TimetableViewModelModule(add);

                Console.WriteLine("\t on "+this+" ->  "+this.GetHashCode()+"\n");

                foreach (TimetableViewModelModule ttvmm in findDependentModules(add, _ModuleList))
                {
                    Inititalize_TimetableViewModelModule(ttvmm);
                }
            }
        }
        private void OnModuleRemove(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (TimetableModule t in e.NewItems)
            {
                //t.PropertyChanged -= (sender, e) => OnModuleChange(sender, e, ttvmm);
                TimetableViewModelModule foundTTVMM = findTimetableViewModelMoudle(t, _ModuleList);
                List<TimetableViewModelModule> dependencies = findDependentModules(foundTTVMM, _ModuleList);
            }
        }
        private void OnModuleClear(object sender, NotifyCollectionChangedEventArgs e)
        {
            _ModuleList.Clear();
        }
        #endregion

        #region Properties
        private ObservableCollection<TimetableViewModelModule> _ModuleList = new ObservableCollection<TimetableViewModelModule>();
        public ObservableCollection<TimetableViewModelModule> ModuleList
        {
            get { return _ModuleList; }
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
                if (_DialogOpen_ButtonCommand == null)
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
}

namespace Frontend.Models{
    public class TimetableViewModelModule : NotifyPropertyValueChange
    {
        private double _X;
        private double _Y;
        private double _Width;
        private double _Height;
        private string  _Color;
        private TimetableModule _Module;


        public double X { get { return _X; } 
            set {
                var oldValue = _X;
                _X = value;
                NotifyPropertyChanged("X", oldValue, value);
            } 
        }

        public double Y { get { return _Y; }
            set
            {
                var oldValue = _Y;
                _Y = value;
                NotifyPropertyChanged("Y", oldValue, value);
            }
        }
        public double Width { get { return _Width; } set
            {
                var oldValue = _Width;
                _Width = value;
                NotifyPropertyChanged("Width", oldValue, value);
            }
        }

        public double Height { get { return _Height; }
            set
            {
                var oldValue = _Height;
                _Height = value;
                NotifyPropertyChanged("Height", oldValue, value);
            }
        }

        public string Color { get { return _Color; } set
            {
                var oldValue = _Color;
                _Color = value;
                NotifyPropertyChanged("Color", oldValue, value);
            }
        }
        public TimetableModule Module { get { return _Module; } 
            set
            {
                var oldValue = _Module;
                _Module = value;
                NotifyPropertyChanged("Module", oldValue, value);
            }
        }

    }
}

