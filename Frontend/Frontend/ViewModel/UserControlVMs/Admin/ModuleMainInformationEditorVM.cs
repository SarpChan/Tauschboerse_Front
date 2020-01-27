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

            //ZUM TEST
            _StudyProgramDict.Add(17, "Informatik");
            _StudyProgramDict.Add(42, "Schachwissenschaften");

            _FieldOfStudyDict.Add(1, "Medieninformatik");
            _FieldOfStudyDict.Add(2, "Medieninformatik 2 - Hilfe nicht noch mal");
            _FieldOfStudyDict.Add(3, "Medieninformatik 3 - Ist das ein Scherz");
            _FieldOfStudyDict.Add(4, "Medieninformatik 17 - Ich will nicht mehr");

            _ModuleDict.Add(1, "Mathe 7 - Bewiesen ist noch garnichts");
            _ModuleDict.Add(2, "Dokumentation schreiben lernen (so nicht MS)");
            _ModuleDict.Add(4, "Kaffee, Klaviertasten und Comedians - (Dumme Namen für Sprachen)");

            _SemesterDict.Add(3, "SS 2010");
            _SemesterDict.Add(4, "WS 2019/2020");
            _SemesterDict.Add(5, "WS 2030/2031");
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

        private Dictionary<long, string> _ModuleDict = new Dictionary<long, string>();
        public Dictionary<long, string> ModuleDict
        {
            get { return _ModuleDict; }
            set { _ModuleDict = value; }
        }

        private Dictionary<long, string> _SemesterDict = new Dictionary<long, string>();
        public Dictionary<long, string> SemesterDict
        {
            get { return _SemesterDict; }
            set { _SemesterDict = value; }
        }
    }
}
