using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
using NSwag.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Frontend.ViewModel
{
    class AdminPageViewModel : ViewModelBase
    {
        #region Properties

        public ObservableCollection<FieldOfStudy> FieldOfStudyList { get; } = new ObservableCollection<FieldOfStudy>();

        public ObservableCollection<StudyProgram> StudyProgramList { get; } = new ObservableCollection<StudyProgram>();

        public ObservableCollection<ExamRegulation> ExamRegulationList { get; } = new ObservableCollection<ExamRegulation>();

        public ObservableCollection<string> SemesterList { get; } = new ObservableCollection<string>();

        #endregion

        public AdminPageViewModel()
        {

            Console.WriteLine("\nNEW ADMINPAGEVM -> " + this.GetHashCode());

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
            var foSList = JsonConvert.DeserializeObject<List<FieldOfStudy>>(response.Content.ToString());
            FillFieldOfStudyList(foSList);
        }



        public void FillFieldOfStudyList(List<FieldOfStudy> list)
        {
            FieldOfStudyList.Clear();
            StudyProgramList.Clear();
            ExamRegulationList.Clear();

            foreach (var foS in list)
            {
                Console.WriteLine("FOS :" + foS.Title);
                FieldOfStudyList.Add(foS);
            }

        }


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

        public async void LoadNewTimeTable(string term)
        {
            try
            {
                await RequestAdminTimetableServerAsync(term);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task RequestAdminTimetableServerAsync(string term)
        {

            ObservableCollection<TimetableModule> tempTable = new ObservableCollection<TimetableModule>();
            APIClient apiClient = APIClient.Instance;
            //TODO: Backend muss mit der ExamRegulation + Term funktionieren
            var response = await apiClient.NewGETRequest("/rest/lists/date_timetable/"+term);
            if ((int)response.StatusCode >= 400) return;

            tempTable = JsonConvert.DeserializeObject<ObservableCollection<TimetableModule>>(response.Content.ToString());
            foreach (TimetableModule tm in tempTable)
            {
                tm.Day = Globals.dayValues[tm.Day];
            }

            ModuleListModel.Instance.SetList(tempTable);

        }

    }
}
