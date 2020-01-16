﻿using Frontend.Helpers;
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

        private double totalWidth
        {
            get; set;
        }

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
            foreach(TimetableViewModelModule ttvmm in _ModuleList)
            {
                TimeToYCoordinatesConverter timeToYCoordinatesConverter = new TimeToYCoordinatesConverter();
                //ttvmm.X = timeToYCoordinatesConverter.Convert()
                Inititalize_TimetableViewModelModule(ttvmm);
                calculateValues(ttvmm, _ModuleList);
            }
        }

        private List<TimetableViewModelModule> findDependentModules(TimetableViewModelModule module, IList<TimetableViewModelModule> moduleList)
        {
            List<TimetableViewModelModule> dependencies = new List<TimetableViewModelModule>();
            foreach(TimetableViewModelModule i in moduleList)
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
            foreach(TimetableViewModelModule ttvmm in moduleList)
            {
                if (ttvmm.Module.Equals(t))
                {
                    return ttvmm;
                }
            }
            return null;
        }

        private void calculateValues(TimetableViewModelModule module, IList<TimetableViewModelModule> moduleList)
        {
            module.X = TimeCoodinatesCalculator.ConvertTimeToXCoordinates(100, 100, int.Parse(module.Module.Day), module.Module, moduleListModel.ModuleList);
        }

        private void Inititalize_TimetableViewModelModule(TimetableViewModelModule ttvmm)
        {
            if(ttvmm.Module != null)
            {
                /*Meldet die Methode OnModuleChange auf die PropertyChanged des Modules an und gibt das ttvmm als festen Parameter mit"*/
                ttvmm.Module.PropertyChanged += (sender, e) => OnModuleChange(sender, e, ttvmm);
            }
            
        }

        private void OnModuleChange(object sender, PropertyChangedEventArgs e, TimetableViewModelModule ttvmm)
        {
            var args = e as PropertyChangedExtendedEventArgs;


            switch (e.PropertyName)
            {
                case "Name": OnNameChange(sender, args, ttvmm);break;
                case "StartTime": OnStartTimeChange(sender, args,ttvmm);break;
                case "EndTime": OnEndTimeChange(sender, args,ttvmm);break;
                case "Day": OnDayChange(sender, args,ttvmm); break;
                case "Type": OnTypeChange(sender, args,ttvmm); break;
            }
        }

        private void OnNameChange(object sender, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {
            Console.WriteLine("Change Name");
            TimetableModule ttm = sender as TimetableModule;

            ttvmm.Color = ColorGenerator.generateColor(ttm.CourseName,ttm.Type);


        }
        private void OnStartTimeChange(object sender, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {

        }
        private void OnEndTimeChange(object sender, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {

        }
        private void OnDayChange(object sender, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {

        }
        private void OnTypeChange(object sender, PropertyChangedExtendedEventArgs e, TimetableViewModelModule ttvmm)
        {

        }
        private void OnModuleAdd(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach(TimetableModule t in e.NewItems)
            {
                TimetableViewModelModule add = new TimetableViewModelModule
                {
                    Module = t
                };
                _ModuleList.Add(add);
                calculateValues(add, _ModuleList);
                foreach(TimetableViewModelModule ttvmm in findDependentModules(add, _ModuleList))
                {
                    calculateValues(ttvmm, _ModuleList);
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

    public class TimetableViewModelModule
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Color { get; set; }
        public TimetableModule Module { get; set; }

    }

}
