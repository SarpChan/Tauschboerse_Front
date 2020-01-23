using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
    class ModuleMainInformationEditorVM : ModuleEditorVM
    {

        public ModuleMainInformationEditorVM()
        {
            _StudyProgramDict.Add(17, "Informatik");
            _StudyProgramDict.Add(42, "Schachwissenschaften");

            _FieldOfStudyDict.Add(1, "Medieninformatik");
            _FieldOfStudyDict.Add(2, "Medieninformatik 2 - Hilfe nicht noch mal");
            _FieldOfStudyDict.Add(3, "Medieninformatik 3 - Ist das ein Scherz");
            _FieldOfStudyDict.Add(4, "Medieninformatik 17 - Ich will nicht mehr");
        }


        private Dictionary<long, string> _FieldOfStudyDict = new Dictionary<long, string>();
        public Dictionary<long, string> FieldOfStudyDict
        {
            get { return _FieldOfStudyDict; }
            set { _FieldOfStudyDict = value; }
        }

        private Dictionary<long, string> _StudyProgramDict = new Dictionary<long, string>();
        public Dictionary<long, string> StudyProgramDict
        {
            get { return _StudyProgramDict; }
            set { _StudyProgramDict = value; }
        }
    }
}
