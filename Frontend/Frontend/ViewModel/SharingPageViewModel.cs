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
        private ObservableCollection<SwapOfferFrontendModel> _SwapListPublic = new ObservableCollection<SwapOfferFrontendModel>();
        public ObservableCollection<SwapOfferFrontendModel> SwapListPublic
        {
            get { return _SwapListPublic; }
        }

        private ObservableCollection<SwapOfferFrontendModel> _SwapListOwn = new ObservableCollection<SwapOfferFrontendModel>();
        public ObservableCollection<SwapOfferFrontendModel> SwapListOwn
        {
            get { return _SwapListOwn; }
        }

        public string Siebzehn
        {
            get { return "17"; }
        }

        public SharingPageViewModel()
        {
            /*
        public long Id { get; set; }
        public int Slots { get; set; }
        public char GroupChar { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public Term Term { get; set; }
        public CourseComponent CourseComponent { get; set; }
        public Lecturer Lecturer { get; set; }
        public Room Room { get; set; }
        public HashSet<Student> Students { get; set; }
        public HashSet<StudentPrioritizesGroup> StudentPrioritizesGroups { get; set; }

            public long Id { get; set; }
        public CourseType Type { get; set; }
        public int CreditPoints { get; set; }
        public string Exam { get; set; }
        public HashSet<Group> Groups { get; set; }
        public long CourseId { get; set; }
        public StudentPassedExam StudentPassedExam { get; set; }
             
            SwapListOwn.Add(new SwapOffer
            {
                id = 1,
                date = new DateTime(2020,01,17),
                student = null,
                fromGroup = new Group(),
                toGroup = new Group
                {
                    GroupChar = 'D',
                    Day = Models.DayOfWeek.MONDAY,
                    StartTime = new DateTime(1,1,1,8,15,0),
                    EndTime = new DateTime(1, 1, 1, 9, 45, 0),
                    CourseComponent = new CourseComponent
                    {
                        Type = new CourseType
                    }
                }
            });*/
            SwapListOwn.Add(new SwapOfferFrontendModel
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

            SwapListPublic.Add(new SwapOfferFrontendModel
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
            Console.WriteLine("Added;");

            Console.WriteLine(this.GetHashCode());
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
