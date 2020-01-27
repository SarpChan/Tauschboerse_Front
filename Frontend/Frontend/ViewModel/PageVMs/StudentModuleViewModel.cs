﻿using Frontend.Helpers;
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

namespace Frontend.ViewModel
{
    class StudentModuleViewModel : ViewModelBase
    {
        private ModuleListModel moduleListModel = ModuleListModel.Instance;
        

        public StudentModuleViewModel()
        {
            List<int> tempSemesterList = new List<int>();
            foreach (var moduleItem in moduleListModel.ModuleItemList)
            {
                //_modules.Add(moduleItem);
                Boolean found = false;
                foreach(var semester in tempSemesterList)
                {
                    if(moduleItem.semester == semester)
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
            
            
            for(int i = 0;i<tempSemesterList.Count;i++)
            {
                NumberOfSemesters.Add(tempSemesterList[i]);
            }

            Console.WriteLine(NumberOfSemesters); 
            
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
            Console.WriteLine("KLICK"+i.ToString());
            int semester = (int)i;
            Modules.Clear();
            foreach (var moduleItem in moduleListModel.ModuleItemList){
                if(moduleItem.semester == semester)
                {
                    Modules.Add(moduleItem);
                }
            }

        }

        private void CheckboxIsChecked(object i)
        {
            Console.WriteLine("isChecked" + (long) i);
        }

        private void CheckboxIsUnChecked(object i)
        {
            Console.WriteLine("uncheck");
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
        #endregion
    }

    public class CurriculumDummy
    {
        public int Terms { get; set; }

    }
    
}
