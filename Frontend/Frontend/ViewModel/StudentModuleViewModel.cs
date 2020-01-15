﻿using Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Helpers;
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
            ModuleItem moduleItem1 = new ModuleItem(1, "prog3", 5, 3, moduleListModel.ModuleList);
            ModuleItem moduleItem2 = new ModuleItem(2, "prog17", 5, 1, moduleListModel.ModuleList);
            moduleListModel.ModuleItemList.Add(moduleItem1);
            moduleListModel.ModuleItemList.Add(moduleItem2);


            List<int> tempSemesterList = new List<int>();
            foreach (var moduleItem in moduleListModel.ModuleItemList)
            {
                _modules.Add(moduleItem);
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
                    // 1. Argument: Kommando-Effekt (Execute), 2. Argument: Bedingung "Kommando aktiv?" (CanExecute)
                    _SwitchTermCommand = new ActionCommand(dummy => this.SwitchTerm());
                }
                return _SwitchTermCommand;
            }
        }
        #endregion


        // Hilfsmethode für SwitchTermCommand
        private void SwitchTerm()
        {
            /*Console.WriteLine("KLICK");
            var request = new RestRequest("rest/lists/timetable}", Method.GET);
            //request.AddParameter("stadtname", "vollradisroda", ParameterType.UrlSegment);

            var m = client.Execute< ObservableCollection<TimetableModule>>(request);

            _modules = m.Data;

            Console.WriteLine(_modules.Count);
            foreach (TimetableModule mod in _modules){
                
                Console.WriteLine(mod.CourseName);
            }*/
        }

        #region properties
        private ObservableCollection<int> _numberOfSemesters = new ObservableCollection<int>();
        public ObservableCollection<int> NumberOfSemesters
        {
            get { return _numberOfSemesters; }
        }

        private static ObservableCollection<ModuleItem> _modules = new ObservableCollection<ModuleItem>();
        public ObservableCollection<ModuleItem> Modules
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
