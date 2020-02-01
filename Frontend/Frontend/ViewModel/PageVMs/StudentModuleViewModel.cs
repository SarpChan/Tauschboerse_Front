using Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Frontend.Models;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Collections.Specialized;

using RestSharp;
using System.ComponentModel;

namespace Frontend.ViewModel
{
    class StudentModuleViewModel : ViewModelBase
    {
        private ModuleListModel moduleListModel = ModuleListModel.Instance;


        public StudentModuleViewModel()
        {
            moduleListModel.ModuleList.Clear();
            List<int> tempSemesterList = new List<int>();
            foreach (var moduleItem in moduleListModel.ModuleItemList)
            {
                //_modules.Add(moduleItem);
                Boolean found = false;
                foreach (var semester in tempSemesterList)
                {
                    if (moduleItem.semester == semester)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    //NumberOfSemesters.Add(moduleItem.semester);
                    tempSemesterList.Add(moduleItem.semester);
                }

            }
            tempSemesterList = tempSemesterList.OrderBy(i => i).ToList();


            for (int i = 0; i < tempSemesterList.Count; i++)
            {
                NumberOfSemesters.Add(tempSemesterList[i]);
            }


        }

        #region ICommands
        private ICommand _SwitchTermCommand;
        public ICommand SwitchTermCommand
        {
            get
            {
                if (_SwitchTermCommand == null)
                {
                    _SwitchTermCommand = new ActionCommand(param => this.SwitchTerm(param));
                }
                return _SwitchTermCommand;
            }
        }

        private ICommand _IsCompletedCheckedCommand;
        public ICommand IsCompletedCheckedCommand
        {
            get
            {
                if (_IsCompletedCheckedCommand == null)
                {
                    _IsCompletedCheckedCommand = new ActionCommand(param => this.CheckboxIsChecked(param));
                }
                return _IsCompletedCheckedCommand;
            }
        }

        private ICommand _IsCompletedUnCheckedCommand;
        public ICommand IsCompletedUnCheckedCommand
        {
            get
            {
                if (_IsCompletedUnCheckedCommand == null)
                {
                    _IsCompletedUnCheckedCommand = new ActionCommand(param => this.CheckboxIsUnChecked(param));
                }
                return _IsCompletedUnCheckedCommand;
            }
        }

        #endregion


        // Hilfsmethode für SwitchTermCommand
        private void SwitchTerm(object i)
        {
            int semester = (int)i;
            Modules.Clear();
            foreach (var moduleItem in moduleListModel.ModuleItemList)
            {
                if (moduleItem.semester == semester)
                {
                    Modules.Add(moduleItem);
                }
            }

        }

        private void CheckboxIsChecked(object i)
        {
            Dictionary<String, String> weekdays = new Dictionary<String, String>() { { "MONDAY", "0" }, { "TUESDAY", "1" }, { "WEDNESDAY", "2" }, { "THURSDAY", "3" }, { "FRIDAY", "4" }, { "SATURDAY", "5" } };
            foreach (var moduleItem in moduleListModel.ModuleItemList)
            {

                if (moduleItem.Id == (long)i)
                {
                    moduleItem.IsChecked = true;
                    CPSum += moduleItem.CreditPoints;
                    foreach (var timetableModule in moduleItem.timetableModules)
                    {
                        if (weekdays.ContainsKey(timetableModule.Day))
                        {
                            timetableModule.Day = weekdays[timetableModule.Day];
                        }


                        moduleListModel.ModuleList.Add(timetableModule);
                    }
                }
            }


        }

        private void CheckboxIsUnChecked(object i)
        {
            foreach (var moduleItem in moduleListModel.ModuleItemList)
            {
                
                if (moduleItem.Id == (long)i)
                {
                    moduleItem.IsChecked = false;
                    CPSum -= moduleItem.CreditPoints;
                    foreach (var timetableModule in moduleItem.timetableModules)
                    {
                        moduleListModel.ModuleList.Remove(timetableModule);
                    }
                }
            }
        }

        #region properties
        private ObservableCollection<int> _numberOfSemesters = new ObservableCollection<int>();
        public ObservableCollection<int> NumberOfSemesters
        {
            get { return _numberOfSemesters; }
        }

        private static ObservableCollection<ModuleSelectionItem> _modules = new ObservableCollection<ModuleSelectionItem>();
        public ObservableCollection<ModuleSelectionItem> Modules
        {
            get { return _modules; }
        }

        private int _cpSum = 0;
        public int CPSum
        {
            get { return _cpSum; }
            set
            {
                if (_cpSum != value)
                {
                    _cpSum = value;
                    OnPropertyChanged("CPSum");
                }
            }

            #endregion
        }
    }

    public class CurriculumDummy
    {
        public int Terms { get; set; }

    }
    
}
