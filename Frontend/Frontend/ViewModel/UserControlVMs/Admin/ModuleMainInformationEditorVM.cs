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

            //Bsp Datensaetzte da es eh nicht berabeiten werden kann
            _ModuleDict.Add(1, "Mathe 7 - Bewiesen ist noch garnichts");
            _ModuleDict.Add(2, "Dokumentation schreiben lernen (so nicht MS)");
            _ModuleDict.Add(4, "Kaffee, Klaviertasten und Comedians - (Dumme Namen für Sprachen)");

            _SemesterDict.Add(3, "SS 2010");
            _SemesterDict.Add(4, "WS 2019/2020");
            _SemesterDict.Add(5, "WS 2030/2031");

            LoadFieldOfStudyList();
        }

        public ObservableCollection<FieldOfStudy> FieldOfStudyList { get; } = new ObservableCollection<FieldOfStudy>();

        public ObservableCollection<StudyProgram> StudyProgramList { get; } = new ObservableCollection<StudyProgram>();

        public ObservableCollection<ExamRegulation> ExamRegulationList { get; } = new ObservableCollection<ExamRegulation>();

        public ObservableCollection<string> SemesterList { get; } = new ObservableCollection<string>();

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
            if ((int)response.StatusCode >= 400) return;
            var foSList = JsonConvert.DeserializeObject<List<FieldOfStudy>>(response.Content.ToString());
            FillFieldOfStudyList(foSList);
        }

        /// <summary>
        ///  Fuellt die FieldOfStudyList[Observable] mit einer List von FieldOfStudys
        /// </summary>
        /// <param name="list">Die neue Liste die zum fuellen der ObserableList [FieldOfStudyList] benutzt wird</param>
        public void FillFieldOfStudyList(List<FieldOfStudy> list)
        {
            FieldOfStudyList.Clear();
            StudyProgramList.Clear();
            ExamRegulationList.Clear();

            foreach (var foS in list)
            {
                FieldOfStudyList.Add(foS);
            }

        }

        /// <summary>
        /// Fuellt die StudyProgramList[Observable] mit FieldOfStudy.StudyPrograms(List<StudProgram>)
        /// </summary>
        /// <param name="fieldOfStudy">Das ausgewaehlte FieldOfStudy</param>
        public void FillStudyProgramList(FieldOfStudy fieldOfStudy)
        {



            if (fieldOfStudy.StudyPrograms != null)
            {
                StudyProgramList.Clear();

                foreach (var Sp in fieldOfStudy.StudyPrograms)
                {
                    StudyProgramList.Add(Sp);
                }
            }
        }

        /// <summary>
        /// Fuellt die ExamRegulationList[Observable] 
        /// </summary>
        /// <param name="studyProgram">Das ausgewaehlte studyProgram</param>
        public void FillExamRegulationList(StudyProgram studyProgram)
        {
            if (studyProgram.ExamRegulations != null)
            {
                ExamRegulationList.Clear();
                foreach (ExamRegulation eR in studyProgram.ExamRegulations)
                {
                    ExamRegulationList.Add(eR);
                }
            }
        }

        /// <summary>
        /// Fuellt die SemesterList[Observable]
        /// </summary>
        /// <param name="examRegulation">Die ausgeaehlte ExamRegulation</param>
        public void FillSemesterList(ExamRegulation examRegulation)
        {
            if (examRegulation != null)
            {
                SemesterList.Clear();
                for (int i = 1; i <= examRegulation.MaxTerms; i++)
                {
                    SemesterList.Add(i.ToString());
                }

            }

        }
    }
}
