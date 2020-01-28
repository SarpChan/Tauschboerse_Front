using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Frontend.ViewModel
{
    class ModuleMainInformationEditorVM : ModuleEditorVM
    {

        public ModuleMainInformationEditorVM()
        {

            //ZUM TEST
            _ModuleDict.Add(1, "Mathe 7 - Bewiesen ist noch garnichts");
            _ModuleDict.Add(2, "Dokumentation schreiben lernen (so nicht MS)");
            _ModuleDict.Add(4, "Kaffee, Klaviertasten und Comedians - (Dumme Namen für Sprachen)");

            _SemesterDict.Add(3, "SS 2010");
            _SemesterDict.Add(4, "WS 2019/2020");
            _SemesterDict.Add(5, "WS 2030/2031");

            LoadFieldOfStudyList();
        }

        private List<FieldOfStudy> _FieldOfStudyList = new List<FieldOfStudy>();

        private Dictionary<FieldOfStudy, string> _FieldOfStudyDict = new Dictionary<FieldOfStudy, string>();
        public Dictionary<FieldOfStudy, string> FieldOfStudyDict
        {
            get { return _FieldOfStudyDict; }
            set { _FieldOfStudyDict = value; }
        }

        private Dictionary<StudyProgram, string> _StudyProgramDict = new Dictionary<StudyProgram, string>();
        public Dictionary<StudyProgram, string> StudyProgramDict
        {
            get { return _StudyProgramDict; }
            set { _StudyProgramDict = value; }
        }

        private Dictionary<ExamRegulation, string> _ExamRegulationDict = new Dictionary<ExamRegulation, string>();
        public Dictionary<ExamRegulation, string> ExamRegulationDict
        {
            get { return _ExamRegulationDict; }
            set { _ExamRegulationDict = value; }
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

        private async void LoadFieldOfStudyList()
        {
            try {
                await RequestMainInformationDataFromServerAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private async Task RequestMainInformationDataFromServerAsync()
        {
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewGETRequest("/rest/lists/fieldOfStudy");
            Console.WriteLine("[RequestMainInformationDataFromServer]" + response.StatusDescription);
            if ((int)response.StatusCode >= 400) return;

            Console.WriteLine(response.Content.ToString());
            _FieldOfStudyList = JsonConvert.DeserializeObject<List<FieldOfStudy>>(response.Content.ToString());
            FillFieldOfStudyDicts(_FieldOfStudyList);
            
        }

        private void FillFieldOfStudyDicts(List<FieldOfStudy> fieldOfStudyList)
        {
            if(fieldOfStudyList != null)
            {
                FieldOfStudyDict.Clear();
                foreach (FieldOfStudy FoS in fieldOfStudyList)
                {
                    FieldOfStudyDict.Add(FoS, FoS.Title);
                }
            }
            else
            {
                Console.WriteLine("Das FieldOfStudy ist Null");
            }
        }

        public void FillStudyProgramDict(FieldOfStudy fieldOfStudy)
        {
            if(fieldOfStudy.StudyPrograms != null)
            {
                StudyProgramDict.Clear();
                foreach(StudyProgram sP in fieldOfStudy.StudyPrograms)
                {
                    StudyProgramDict.Add(sP, sP.Title);
                }
            }
        }

        public void FillExamRegulationDict(StudyProgram studyProgram)
        {
            if(studyProgram.ExamRegulations != null)
            {
                ExamRegulationDict.Clear();
                foreach(ExamRegulation eR in studyProgram.ExamRegulations)
                {
                    // Datum Format Y de-DE => Oktober 2008
                    ExamRegulationDict.Add(eR, eR.Date.ToString("Y", CultureInfo.CreateSpecificCulture("de-DE")));
                }
            }
        }
    }
}
