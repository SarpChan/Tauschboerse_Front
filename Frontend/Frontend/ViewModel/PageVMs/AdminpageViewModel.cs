﻿using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
using NSwag.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private ObservableDictionary<FieldOfStudy, string> _FieldOfStudyDict = new ObservableDictionary<FieldOfStudy, string>();
        public ObservableDictionary<FieldOfStudy, string> FieldOfStudyDict
        {
            get { return _FieldOfStudyDict; }
            set { _FieldOfStudyDict = value; }
        }

        private ObservableDictionary<StudyProgram, string> _StudyProgramDict = new ObservableDictionary<StudyProgram, string>();
        public ObservableDictionary<StudyProgram, string> StudyProgramDict
        {
            get { return _StudyProgramDict; }
            set { _StudyProgramDict = value; }
        }

        private ObservableDictionary<ExamRegulation, string> _ExamRegulationDict = new ObservableDictionary<ExamRegulation, string>();
        public ObservableDictionary<ExamRegulation, string> ExamRegulationDict
        {
            get { return _ExamRegulationDict; }
            set { _ExamRegulationDict = value; }
        }

        private ObservableDictionary<long, string> _SemesterDict = new ObservableDictionary<long, string>();
        public ObservableDictionary<long, string> SemesterDict
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

        public void FillStudyProgramDict(FieldOfStudy fieldOfStudy)
        {
            if (fieldOfStudy.StudyPrograms != null)
            {
                StudyProgramDict.Clear();
                foreach (StudyProgram sP in fieldOfStudy.StudyPrograms)
                {
                    StudyProgramDict.Add(sP, sP.Title);
                }
            }
        }

        public void FillExamRegulationDict(StudyProgram studyProgram)
        {
            if (studyProgram.ExamRegulations != null)
            {
                ExamRegulationDict.Clear();
                foreach (ExamRegulation eR in studyProgram.ExamRegulations)
                {
                    // Datum Format Y de-DE => Oktober 2008
                    ExamRegulationDict.Add(eR, eR.Date.ToString("Y", CultureInfo.CreateSpecificCulture("de-DE")));
                }
            }
        }


    }
}
