using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class ModuleSelectionItem
    {
        public enum ModuleType { LECTURE, PRACTICE, TUTORIAL };

        public long Id { get; set; }
        public string Title { get; set; }
        public int CreditPoints { get; set; }
        public int semester { get; set; }
        public List<ModuleType> moduleTypes { get; set; }        
        public ObservableCollection<TimetableModule> timetableModules { get; set; }

        public ModuleSelectionItem(long id, string title, int creditPoints, int semester, ObservableCollection<TimetableModule> timetableModules)
        {
            Id = id;
            Title = title;
            CreditPoints = creditPoints;
            this.semester = semester;
            this.timetableModules = timetableModules;
        }

        //public HashSet<Curriculum> Curriculua { get; set; }
        //public HashSet<Course> Courses { get; set; }


    }
}
