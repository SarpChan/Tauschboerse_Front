using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend.Models;
namespace Frontend.ViewModel
{
    class SharingPageViewModel
    {
        private ObservableCollection<SharingPageViewModelSwapOffer> _SwapListPublic = new ObservableCollection<SharingPageViewModelSwapOffer>();
        public ObservableCollection<SharingPageViewModelSwapOffer> SwapListPublic
        {
            get { return _SwapListPublic; }
        }

        private ObservableCollection<SharingPageViewModelSwapOffer> _SwapListOwn = new ObservableCollection<SharingPageViewModelSwapOffer>();
        public ObservableCollection<SharingPageViewModelSwapOffer> SwapListOwn
        {
            get { return _SwapListOwn; }
        }

        List<SwapOfferFrontendModel> TestListOwn = new List<SwapOfferFrontendModel>();
        List<SwapOfferFrontendModel> TestListPublic = new List<SwapOfferFrontendModel>();

        public IEnumerable<String> AutocompleteOwn { get; set; }
        public IEnumerable<String> AutocompletePublic { get; set; }

        public SharingPageViewModel()
        {

            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 0,
                FromGroupChar = 'A',
                ToGroupChar = 'B',
                CourseName = "Programmieren 3",
                CourseType = "Praktikum",
                ToStartTime = new TimeSpan(8,15,0),
                ToEndTime = new TimeSpan(9,45,0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });

            TestListOwn.Add(new SwapOfferFrontendModel
            {
                Id = 0,
                FromGroupChar = 'C',
                ToGroupChar = 'D',
                CourseName = "Programmieren 2",
                CourseType = "Vorlesung",
                ToStartTime = new TimeSpan(8, 15, 0),
                ToEndTime = new TimeSpan(9, 45, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY
            });

            TestListPublic.Add(new SwapOfferFrontendModel
            {
                Id = 0,
                FromGroupChar = 'A',
                ToGroupChar = 'B',
                CourseName = "EIBO",
                CourseType = "Übung",
                ToStartTime = new TimeSpan(10, 0, 0),
                ToEndTime = new TimeSpan(11, 30, 0),
                FromStartTime = new TimeSpan(10, 0, 0),
                FromEndTime = new TimeSpan(11, 30, 0),
                FromDay = Models.DayOfWeek.FRIDAY,
                ToDay = Models.DayOfWeek.MONDAY,
            });

            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[0]));
            SwapListOwn.Add(new SharingPageViewModelSwapOffer(TestListOwn[1]));
            SwapListPublic.Add(new SharingPageViewModelSwapOffer(TestListPublic[0]));

            CreateAutocompletes();

        }

        #region Methods
        private void CreateAutocompletes()
        {
            List<String> autoCompleteConvertList = new List<string>();
            foreach(SharingPageViewModelSwapOffer swapoffer in this.SwapListOwn)
            {
               autoCompleteConvertList.Add(swapoffer.CourseName);
               autoCompleteConvertList.Add(swapoffer.CourseType);
            }
            this.AutocompleteOwn = autoCompleteConvertList.Distinct().ToList(); ;
            foreach (string s in this.AutocompleteOwn) Console.WriteLine(s);
            List<String> autoCompleteConvertList2 = new List<string>();
            foreach (SharingPageViewModelSwapOffer swapoffer in this.SwapListPublic)
            {
                autoCompleteConvertList2.Add(swapoffer.CourseName);
                autoCompleteConvertList2.Add(swapoffer.CourseType);
            }
            this.AutocompletePublic = autoCompleteConvertList2.Distinct().ToList(); ;

        }
        #endregion Methods
        //SPVMSO
        public class SharingPageViewModelSwapOffer
        {
            public string CourseName { get; set; }
            //Könnte auch dann ein Bild sein.
            public string CourseType { get; set; }
            public string Has { get; set; }
            public string Wants { get; set; }
            public long Id { get; set; }

            public SharingPageViewModelSwapOffer(SwapOfferFrontendModel sofm)
            {
                this.CourseName = sofm.CourseName;
                this.CourseType = sofm.CourseType;
                StringBuilder sb = new StringBuilder();
                sb.Append("Gruppe ").Append(sofm.FromGroupChar).Append(" (");
                string tanslateDay = sofm.FromDay.ToString();
                sb.Append(tanslateDay.First().ToString().ToUpper()).Append(tanslateDay.Substring(1).ToLower()).Append(" ");
                //sb.Append(sofm.FromStartTime.Hours).Append(":").Append(sofm.FromStartTime.Minutes).Append(" - ").Append(sofm.FromEndTime.Hours).Append(":").Append(sofm.FromEndTime.Minutes).Append(")");
                sb.Append(sofm.FromStartTime.ToString(@"hh\:mm")).Append(" - ").Append(sofm.FromEndTime.ToString(@"hh\:mm")).Append(")");
                this.Has = sb.ToString();
                sb.Clear();
                sb.Append("Gruppe ").Append(sofm.ToGroupChar).Append(" (");
                tanslateDay = sofm.ToDay.ToString();
                sb.Append(tanslateDay.First().ToString().ToUpper()).Append(tanslateDay.Substring(1).ToLower()).Append(" ");
                sb.Append(sofm.ToStartTime.ToString(@"hh\:mm")).Append(" - ").Append(sofm.ToEndTime.ToString(@"hh\:mm")).Append(")");
                this.Wants = sb.ToString();
                this.Id = sofm.Id;
            }
        }

        public class SwapOfferFrontendModel
        {
            public long Id { get; set; }
            public char FromGroupChar { get; set; }
            public char ToGroupChar { get; set; }
            public string CourseName { get; set; }
            public string CourseType { get; set; }
            public TimeSpan ToStartTime { get; set; }
            public TimeSpan ToEndTime { get; set; }
            public TimeSpan FromStartTime { get; set; }
            public TimeSpan FromEndTime { get; set; }
            public Models.DayOfWeek FromDay { get; set; }
            public Models.DayOfWeek ToDay { get; set; }
        }

    }
}
