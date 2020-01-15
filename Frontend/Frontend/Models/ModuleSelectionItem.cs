using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class ModuleSelectionItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int CreditPoints { get; set; }
        public int semester { get; set; }
        public List<TimetableModule> timetableModules { get; set; }

        public ModuleSelectionItem(long id, string title, int creditPoints, int semester, List<TimetableModule> timetableModules)
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
