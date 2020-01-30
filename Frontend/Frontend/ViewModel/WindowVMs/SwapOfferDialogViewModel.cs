using Frontend.Helpers;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Frontend.ViewModel
{
    class SwapOfferDialogViewModel : ViewModelBase
    {
        private ObservableCollection<SwapOfferCourse> _CourseList = new ObservableCollection<SwapOfferCourse>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferCourse> CourseList
        {
            get { return _CourseList; }
        }

        private List<SwapOfferCourse> DatabaseCourses = new List<SwapOfferCourse>();

        private ObservableCollection<SwapOfferGroup> _GroupList = new ObservableCollection<SwapOfferGroup>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferGroup> GroupList
        {
            get { return _GroupList; }
        }

        private ObservableCollection<SwapOfferCourse> _CourseTypeList = new ObservableCollection<SwapOfferCourse>();
        /// <summary>
        /// Eine Liste mit allen Öffentlichen Tauschangeboten
        /// </summary>
        public ObservableCollection<SwapOfferCourse> CourseTypeList
        {
            get { return _CourseTypeList; }
        }

        private Dictionary<long, List<SwapOfferCourse>> courseDict = new Dictionary<long, List<SwapOfferCourse>>();

        private List<SwapOfferCourse> allSwapOfferCourses = new List<SwapOfferCourse>();

        public SwapOfferDialogViewModel()
        {
            
            FetchFromDatabase();
            FromGroup = "";
        }
        
        public void CourseSelectionChanged(SwapOfferCourse selectedItem)
        {        
            CourseTypeList.Clear();
            GroupList.Clear();
            FromGroup = "";
            foreach (SwapOfferCourse courseType in courseDict[selectedItem.CourseId])
            {
                CourseTypeList.Add(courseType);
            }
        }

        public async void CreateSwapOffer()
        {
            SwapOffer so = new SwapOffer(FromGroupId, ToGroupId);
            Console.WriteLine(FromGroupId + " - " + ToGroupId);
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewPOSTRequest("/rest/swapoffer/insert", so);
            Console.WriteLine(response.Content);
            if ((int)response.StatusCode >= 400) return;
        }

        public void CourseTypeSelectionChanged(SwapOfferCourse selectedItem)
        {
            FromGroup = "Gruppe " + selectedItem.GroupChar;
            GroupList.Clear();
            FromGroupId = selectedItem.GroupId;
            foreach (SwapOfferGroup group in selectedItem.Groups)
            {
                GroupList.Add(group);
            }
        }

        public void GroupSelect(SwapOfferGroup group)
        {
            ChangeLine = "Du wechselst von " + FromGroup + " zu Gruppe " + group.Char;
            ToGroupId = group.Id;
        }
        

        public SwapOfferCourse SelectedCourse {get;set;}

        public string _ChangeLine;
        public string ChangeLine
        {
            get
            {
                return _ChangeLine;
            }
            set
            {
                _ChangeLine = value;
                OnPropertyChanged("ChangeLine");
            }
        }

        private long FromGroupId = 0;
        private long ToGroupId = 0;

        public string _FromGroup;
        public string FromGroup
        {
            get
            {
                return _FromGroup;
            } set
            {
                _FromGroup = value;
                OnPropertyChanged("FromGroup");
            }
        }
        
        public void FillList()
        {
            foreach (SwapOfferCourse swapOfferCourse in this.DatabaseCourses)
            {
                List<SwapOfferCourse> fill = new List<SwapOfferCourse>();
                bool found = this.courseDict.TryGetValue(swapOfferCourse.CourseId, out fill);
                if(!found)
                {
                    this.courseDict[swapOfferCourse.CourseId] = new List<SwapOfferCourse>();
                    CourseList.Add(swapOfferCourse);    
                }
                this.courseDict[swapOfferCourse.CourseId].Add(swapOfferCourse);
            

        }
        }

        public async void FetchFromDatabase()
        {
            APIClient api = APIClient.Instance;
            var response = await api.NewGETRequest("/rest/lists/availableSwaps");
            Console.WriteLine(response.Content);
            this.DatabaseCourses = JsonConvert.DeserializeObject<List<SwapOfferCourse>>(response.Content);
            FillList();

           
        }
        
    }
}
