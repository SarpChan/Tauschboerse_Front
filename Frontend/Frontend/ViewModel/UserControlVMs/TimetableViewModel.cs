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
        //private TaskFactory taskFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

        public TimetableViewModel()
        {

            Console.WriteLine("NEW TIMETABLEVIEWMODEL ->  "+this.GetHashCode());
            foreach (var module in moduleListModel.ModuleList)
            {
                OnModuleAdd(module);
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

        #region Properties
        private ObservableCollection<TimetableViewModelModule> _TTVMMList = new ObservableCollection<TimetableViewModelModule>();
        public ObservableCollection<TimetableViewModelModule> TTVMMList
        {
            get { return _TTVMMList; }
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
        
        private double _TotalWidth;
        public double TotalWidth
        {
            get { return _TotalWidth; }
            set
            {
                _TotalWidth = value;
                OnTotalWitdhChange(_TotalWidth);
            }
        }

        private double _TimeWitdh;
        public double TimeWidth
        {
            get { return _TimeWitdh; }
            set
            {
                _TimeWitdh = value;
                OnTimeWidthtChange(_TimeWitdh);
            }
        }

        private double _TotalHeight;
        public double TotalHeight
        {
            get { return _TotalHeight; }
            set
            {
                _TotalHeight = value;
                OnTotalHeightChange(_TotalHeight);
            }
        }
        #endregion

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

        #region OnPropertyChangeMethods

        #region CollectionChanged

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

        private void OnModuleAdd(object sender, NotifyCollectionChangedEventArgs e)
        {

            foreach (TimetableModule t in e.NewItems)
            {
                OnModuleAdd(t);
            }
        }

        private void OnModuleAdd(TimetableModule t)
        {
            TimetableViewModelModule add = new TimetableViewModelModule
            {
                Module = t
            };
            Inititalize_TimetableViewModelModule(add);
            TTVMMList.Add(add);

            BindListenerOn_TimetableViewModelModule(add);

            foreach (TimetableViewModelModule ttvmm in findDependentModules(add, _TTVMMList))
            {
                Inititalize_TimetableViewModelModule(ttvmm);
            }
        }

        private void OnModuleRemove(object sender, NotifyCollectionChangedEventArgs e)
        {
            List<TimetableViewModelModule> changeTTVMM = new List<TimetableViewModelModule>();


            foreach (TimetableModule t in e.OldItems)
            {

                foreach(TimetableViewModelModule ttvmm in TTVMMList)
                {
                    if(ttvmm.Module == t)
                    {
                        changeTTVMM.Add(ttvmm);
                    }
                }

                foreach(TimetableViewModelModule ttvmm  in changeTTVMM)
                {
                    TTVMMList.Remove(ttvmm);
                }

                
            }
        }

        private void OnModuleClear(object sender, NotifyCollectionChangedEventArgs e)
        {
            _TTVMMList.Clear();
        }

        #endregion

        #region ViewChanged
        private void OnTimeWidthtChange(double newValue)
        {
            foreach (TimetableViewModelModule ttvmm in _TTVMMList)
            {
                ttvmm.Width = TimeCoodinatesCalculator.ConvertDayToItemWidth(TotalWidth,newValue, ttvmm, moduleListModel.ModuleList);
                ttvmm.X = TimeCoodinatesCalculator.ConvertTimeToXCoordinates(TotalWidth,newValue, int.Parse(ttvmm.Module.Day), ttvmm, moduleListModel.ModuleList);
            }
        }

        private void OnTotalHeightChange(double newValue)
        {
            foreach (TimetableViewModelModule ttvmm in _TTVMMList)
            {
                RecalculateTimeDependetProperties(ttvmm);
            }
        }

        private void OnTotalWitdhChange(double newValue)
        {

            foreach (TimetableViewModelModule ttvmm in _TTVMMList)
            {
                ttvmm.Width = TimeCoodinatesCalculator.ConvertDayToItemWidth(newValue, TimeWidth, ttvmm, moduleListModel.ModuleList);
                ttvmm.X = TimeCoodinatesCalculator.ConvertTimeToXCoordinates(newValue, TimeWidth, int.Parse(ttvmm.Module.Day), ttvmm, moduleListModel.ModuleList);
            }
        }

        #endregion

        #region ModelChanged
        private void OnModuleChange(object sender, PropertyChangedEventArgs e, TimetableViewModelModule ttvmm)
        {
            var args = e as PropertyChangedExtendedEventArgs;
            var ttm = sender as TimetableModule;


            switch (e.PropertyName)
            {
                case "CourseName": OnNameChange(ttm, args, ttvmm); break;
                case "StartTime": OnTimeChange(ttm, args, ttvmm); break;
                case "EndTime": OnTimeChange(ttm, args, ttvmm); break;
                case "Day": OnDayChange(ttm, args, ttvmm); break;
                case "Type": OnTypeChange(ttm, args, ttvmm); break;
            }
        }

        private void OnNameChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {
            ttvmm.Color = ColorGenerator.generateColor(ttm.CourseName, ttm.Type);
        }

        private void OnTimeChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {
            RecalculateTimeDependetProperties(ttvmm);

            foreach (var d in findDependentModules(ttvmm,_TTVMMList))
            {
                RecalculateTimeDependetProperties(d);
            }
        }

        private void RecalculateTimeDependetProperties(TimetableViewModelModule ttvmm)
        {
            TimeSpan start = TimeSpan.Parse(ttvmm.Module.StartTime);
            TimeSpan end = TimeSpan.Parse(ttvmm.Module.EndTime);

            if (start > end)
            {
                throw new StartTimeLaterThenEndTimeException("Die Startzeit ist spaeter als die Anfangszeit !", start, end);
            }

            ttvmm.Y = TimeCoodinatesCalculator.ConvertTimeToYCoordinates(TotalHeight, start);
            ttvmm.Height = TimeCoodinatesCalculator.ItemHeightConverter(TotalHeight, start, end);
        }


        private void OnDayChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {
            ttvmm.X = TimeCoodinatesCalculator.ConvertTimeToXCoordinates(TotalWidth, TimeWidth, Convert.ToInt32(ttm.Day), ttvmm, moduleListModel.ModuleList);
        }

        private void OnTypeChange(TimetableModule ttm, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {
            ttvmm.Color = ColorGenerator.generateColor(ttm.CourseName, ttm.Type);
        }


        #endregion

        #endregion

        #region Methods

        private void AddModule()

        {
            //ZUM TESTEN [wird momentan nicht benutzt]
            TimetableModule add = new TimetableModule()

            {

                ID = ((int)(new Random().NextDouble() * 50) + 1),

                StartTime = "08:15",

                EndTime = "12:30",

                Day = "3",

                PersonName = "Nicky",

                RoomNumber = "D40",

                CourseName = "TEST",

                GroupChar = "Z",

            };

            moduleListModel.ModuleList.Add(add);
        }

        private void CalculateInitialValues()
        {
            foreach (TimetableViewModelModule ttvmm in _TTVMMList)
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
            RecalculateTimeDependetProperties(ttvmm);
           
            /*Meldet die Methode OnModuleChange auf die PropertyChanged des Modules an und gibt das ttvmm als festen Parameter mit"*/
            ttvmm.Width = TimeCoodinatesCalculator.ConvertDayToItemWidth(TotalWidth, TimeWidth, ttvmm, moduleListModel.ModuleList);
            ttvmm.X = TimeCoodinatesCalculator.ConvertTimeToXCoordinates(TotalWidth, TimeWidth, int.Parse(ttvmm.Module.Day), ttvmm, moduleListModel.ModuleList);
            ttvmm.Color = ColorGenerator.generateColor(ttvmm.Module.CourseName, ttvmm.Module.Type);

            Console.WriteLine("\t\t(after) ->  Color:" + ttvmm.Color + " Y:" + ttvmm.Y +
                "  X:" + ttvmm.X + "  H:" + ttvmm.Height + " W:" + ttvmm.Width);

        }

        private void BindListenerOn_TimetableViewModelModule(TimetableViewModelModule ttvmm)
        {
            ttvmm.Module.PropertyChanged += (sender, e) => OnModuleChange(sender, e, ttvmm);
        }

        //Hilfsmethode fuer OpenDialogCommand

        #endregion

    }
}

