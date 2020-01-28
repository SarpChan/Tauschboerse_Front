using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Frontend.ViewModel
{
    class AdminPageViewModel: ViewModelBase
    {
        #region Properties
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

        private Dictionary<long, string> _SemesterDict = new Dictionary<long, string>();
        public Dictionary<long, string> SemesterDict
        {
            get { return _SemesterDict; }
            set { _SemesterDict = value; }
        }

        #endregion

        public AdminPageViewModel()
        {

            Console.WriteLine("\nNEW ADMINPAGEVM -> "+this.GetHashCode());

            LoadFieldOfStudyList();
        }

        private async void LoadFieldOfStudyList()
        {
            try
            {
                await RequestMainInformationDataFromServerAsync();
            }
            catch (Exception ex)
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
            if (fieldOfStudyList != null)
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

    }
}
