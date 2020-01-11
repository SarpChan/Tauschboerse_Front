using Frontend.Helpers;
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
    class StudentModuleViewModel : Helpers.ViewModelBase
    {
        CurriculumDummy curriculum = new CurriculumDummy() { Terms = 7 };



        private ObservableCollection<int> _numberOfSemesters = new ObservableCollection<int>();
        public ObservableCollection<int> numberOfSemesters
        {
            get { return _numberOfSemesters; }
        }

        private static ObservableCollection<Module> _modules = new ObservableCollection<Module>();
        public ObservableCollection<Module> modules
        {
            get { return _modules; }
        }

        static RestClient client = new RestClient("http://localhost:8080/");

        public StudentModuleViewModel()
        {
            for (int i = 1; i <= curriculum.Terms; i++)
            {
                _numberOfSemesters.Add(i);
                Console.WriteLine(numberOfSemesters);
            }
        }


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


        // Hilfsmethode für SwitchTermCommand
        private void SwitchTerm()
        {
            Console.WriteLine("KLICK");
            var request = new RestRequest("rest/lists/timetable}", Method.GET);
            //request.AddParameter("stadtname", "vollradisroda", ParameterType.UrlSegment);

            var m = client.Execute< ObservableCollection<Module>>(request);

            _modules = m.Data;

            Console.WriteLine(_modules.Count);
            foreach (Module mod in _modules){
                
                Console.WriteLine(mod.Title);
            }
        }
    }

    public class CurriculumDummy
    {
        public int Terms { get; set; }

    }

}
