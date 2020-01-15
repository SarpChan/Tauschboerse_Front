using Frontend.Helpers;
using Frontend.Models;
using Frontend.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class TimetableViewModel : ViewModelBase
    {
        private ModuleListModel moduleListModel = ModuleListModel.Instance;
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
            foreach (var day in dayListModel.DayList)
            {
                _DayList.Add(day);
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
}
